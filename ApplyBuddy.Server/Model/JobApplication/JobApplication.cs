using ApplyBuddy.Server.Contracts;
using ApplyBuddy.Server.Model.Common;
using ApplyBuddy.Server.Model.Listings;
using ApplyBuddy.Server.Model.ValueObjects;

namespace ApplyBuddy.Server.Model.JobApplication;

public class JobApplication : AuditableEntity<Guid>, IAggregateRoot
{


    public string Name { get; private set; } = string.Empty;
    public string Notes { get; private set; } = string.Empty;
    // public ApplicationDetails ApplicationDetails { get; private set; }
    public ApplicationState? ApplicationState { get; private set; }
    public List<UserTask> Tasks { get; private set; } = new();
    public Channel? Channel { get; private set; }
    public Guid? ListingId { get; init; }
    
    private JobApplication()
    {
    }
    

    
    // public bool HasBeenSubmitted => ApplicationDetails is ClosedApplicationDetails;

    public static JobApplication CreateWithIdForSeeding(Guid id, Guid listingId, string name, string notes = "")
    {
        return new JobApplication
        {
            Id = id,
            Name = name,
            Notes = notes,
            ListingId = listingId
        };
    }

    public static JobApplication Create(string name, string notes, Guid? listingId = null)
    {
        var id = Guid.NewGuid();
        return new JobApplication
        {
            Id = id,
            // ApplicationDetails = new OpenApplicationDetails(id),
            Name = name,
            Notes = notes,
            ListingId = listingId
        };
    }

    public void Apply(DateTime appliedDate, Channel? channel)
    {
        var details = new ClosedApplicationDetails(appliedDate, channel, Id);
        ApplicationDetails = details;
    }

    public void SetSubmissionDetails(ApplicationDetails details)
    {
        ApplicationDetails = details;
    }
}

public abstract class ApplicationState
{
    public JobApplication Application { get; protected set; } = null!;
    public int CurrentStageIndex { get; protected set; }
    public List<Stage> Stages { get; protected set; } = null!;
    public abstract void MoveToNextStage();
}

public record Stage
{
    public string Name { get; private init; }
    public string? Description { get; private set; }
    public int Order { get; private set; }
}