using ApplyBuddy.Server.Contracts;
using ApplyBuddy.Server.Domain.Common;
using ApplyBuddy.Server.Domain.ValueObjects;
using ApplyBuddy.Server.Features.JobApplications;

namespace ApplyBuddy.Server.Domain.JobApplication;

public class JobApplication : AuditableEntity<Guid>, IAggregateRoot
{


    public string Name { get; private set; } = string.Empty;
    public string Notes { get; private set; } = string.Empty;
    public int StateId { get; private set; }
    public ApplicationState State { get; internal set; }
    
    public AwaitingActionFrom NextActionResponsibility
    {
        get { return State.NextActionResponsibility; }
    }

    public int? CurrentInterviewStage
    {
        get { return State.CurrentInterviewStage; }
    }
    public List<StateTransition> StateTransitions { get; private set; } = new();
    
    public List<UserTask> Tasks { get; private set; } = new();
    public List<InterviewStage> InterviewStages { get; private set; } = new();
    
    public Channel? Channel { get; private set; }
    public Guid? ListingId { get; init; }

    #region Constructors and smart constructors
    private JobApplication()
    {
        State = new NewApplication(this);
    }
    
    public static JobApplication CreateWithIdForSeeding(Guid id, Guid listingId, string name, string notes = "")
    {
        return new JobApplication
        {
            Id = id,
            Name = name,
            Notes = notes,
            ListingId = listingId,
        };
    }

    public static JobApplication Create(string name, string notes, Guid? listingId = null)
    {
        var id = Guid.NewGuid();
        return new JobApplication
        {
            Id = id,
            Name = name,
            Notes = notes,
            ListingId = listingId
        };
    }

    #endregion
    
    public void SubmitInitialApplication()
    {
        var prevState = State;
        State.Advance();
        StateTransitions.Add(new StateTransition(prevState, State, DateTime.UtcNow));
    }

    public DateTime? GetSubmittedDate()
    {
        if (State is InProgress state)
        {
            return state.SubmittedDate;
        }
        throw new InvalidOperationException("Application is not currently in progress.");
    }
    
}

public class Result
{
    public bool IsSuccess { get; }
    public string? Error { get; }
    public bool IsFailure => !IsSuccess;

    protected Result(bool isSuccess, string? error)
    {
        if (isSuccess && !string.IsNullOrEmpty(error))
            throw new InvalidOperationException("A successful result cannot have an error message.");
        
        if (!isSuccess && string.IsNullOrEmpty(error))
            throw new InvalidOperationException("A failure result must have an error message.");

        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new Result(true, null);
    public static Result Failure(string error) => new Result(false, error);
}


public class StateTransition
{
    public ApplicationState PreviousState { get; private set; } = null!;
    public ApplicationState NextState { get; private set; } = null!;
    public DateTime TransitionDate { get; private set; }
    
    private StateTransition() { }
    
    public StateTransition(ApplicationState previousState, ApplicationState nextState, DateTime transitionDate)
    {
        PreviousState = previousState;
        NextState = nextState;
        TransitionDate = transitionDate;
    }
}

public abstract class ApplicationState
{
    public int Id { get; init; }
    protected JobApplication Application { get; init; } = null!;
    public AwaitingActionFrom NextActionResponsibility { get; init; } = AwaitingActionFrom.NoOne;
    public int CurrentInterviewStage { get; protected set; } = -1;
    
    public abstract Result Advance();
    public abstract Result Cancel();
    public abstract Result MarkAsRejected();
    public abstract Result MarkAsSuccessful();

    // private void AddStateTransition(JobApplication application, ApplicationState previousState)
    // {
    //     application.StateTransitions.Add(new StateTransition());
    // }
}

public class NewApplication : ApplicationState
{

    public NewApplication(JobApplication application)
    {
        NextActionResponsibility = AwaitingActionFrom.User;
        Application = application;
    }
    
    public override Result Advance()
    {
        Application.State = new InProgress(NextActionResponsibility, CurrentInterviewStage, Application);
        return Result.Success();
    }
    

    public override Result Cancel()
    {
        Application.State = new Cancelled(NextActionResponsibility, CurrentInterviewStage, Application);
        return Result.Success();
    }
    
    public override Result MarkAsRejected()
    {
        return Result.Failure("Unable to reject as application is not yet submitted.");
    }

    public override Result MarkAsSuccessful()
    {
        return Result.Failure("Unable to mark as successful as application is not yet submitted.");
    }
}

public class InProgress : ApplicationState
{
    public DateTime SubmittedDate { get; } = DateTime.UtcNow;
    public InProgress(AwaitingActionFrom nextActionResponsibilty,
        int currentInterviewStage,
        JobApplication application)
    {
        NextActionResponsibility = nextActionResponsibilty;
        CurrentInterviewStage = currentInterviewStage;
        Application = application;
    }

    public override Result Advance()
    {
       if (CurrentInterviewStage == Application.InterviewStages.Count - 1)
       {
          return Result.Failure(
              "The end of the interview process has been reached. Please mark successful or rejected.");
       }
       
       CurrentInterviewStage++;
       return Result.Success();
    }

    public override Result Cancel()
    {
        Application.State = new Cancelled(AwaitingActionFrom.NoOne, CurrentInterviewStage, Application);
        return Result.Success();
    }

    public override Result MarkAsRejected()
    {
        Application.State = new Rejected(AwaitingActionFrom.NoOne, CurrentInterviewStage, Application);
        return Result.Success();
    }

    public override Result MarkAsSuccessful()
    {
        if (CurrentInterviewStage is -1)
        {
            return Result.Failure("The interview process has not yet started.");
        }

        if (CurrentInterviewStage < Application.InterviewStages.Count - 1)
        {
            return Result.Failure("The end of the interview process has not yet been reached.");
        }
        
        Application.State = new Successful(AwaitingActionFrom.User, CurrentInterviewStage, Application);
        return Result.Success();
    }
}

public class Cancelled : ApplicationState
{
    public Cancelled(AwaitingActionFrom nextActionResponsibilty,
        int currentInterviewStage,
        JobApplication application)
    {
        NextActionResponsibility = nextActionResponsibilty;
        CurrentInterviewStage = currentInterviewStage;
        Application = application;
    }

    public override Result Advance()
    {
        return Result.Failure("Cannot advance from the state of Cancelled.");
    }

    public override Result Cancel()
    {
        return Result.Failure("Application is already cancelled.");
    }
    
    public override Result MarkAsRejected()
    {
        Application.State = new Rejected(NextActionResponsibility, CurrentInterviewStage, Application);
        return Result.Success();
    }

    public override Result MarkAsSuccessful()
    {
        // Not allowed
        return Result.Failure("Cannot mark as successful from the state of Cancelled.");
    }
}

public class Rejected : ApplicationState
{
    public Rejected(AwaitingActionFrom nextActionResponsibilty,
        int currentInterviewStage,
        JobApplication application)
    {
        NextActionResponsibility = nextActionResponsibilty;
        CurrentInterviewStage = currentInterviewStage;
        Application = application;
    }

    public override Result Advance()
    {
        return Result.Failure("Cannot advance from the state of Rejected.");
    }

    public override Result Cancel()
    {
        return Result.Failure("Cannot cancel from the state of Rejected.");
    }
    
    public override Result MarkAsRejected()
    {
        return Result.Failure("Application is already rejected.");
    }

    public override Result MarkAsSuccessful()
    {
        return Result.Failure("Cannot mark as successful from the state of Rejected.");
    }
}

public class Successful : ApplicationState
{
    public Successful(AwaitingActionFrom nextActionResponsibilty,
        int currentInterviewStage,
        JobApplication application)
    {
        NextActionResponsibility = nextActionResponsibilty;
        CurrentInterviewStage = currentInterviewStage;
        Application = application;
    }

    public override Result Advance()
    {
        return Result.Failure("Cannot advance from the state of Successful.");
    }

    public override Result Cancel()
    {
        return Result.Failure("Cannot cancel a successful application.");
    }
    
    public override Result MarkAsRejected()
    {
        return Result.Failure("Cannot mark a successful application as rejected.");
    }

    public override Result MarkAsSuccessful()
    {
        return Result.Failure("Application is already marked as successful.");
    }
}

public record InterviewStage
{
    public string Name { get; private init; } = string.Empty;
    public string? Description { get; private set; }
    public int Order { get; private set; }
    public DateTime DueDate { get; private set; }
}