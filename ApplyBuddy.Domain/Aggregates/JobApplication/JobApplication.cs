using ApplyBuddy.Domain.Common;
using ApplyBuddy.Domain.Enums;
using ApplyBuddy.Domain.Interfaces;
using ApplyBuddy.Domain.ValueObjects;

namespace ApplyBuddy.Domain.Aggregates.JobApplication;
public class JobApplication : AuditableEntity<Guid>, IAggregateRoot
{
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public SubmissionDetails SubmissionDetails { get; private set; }
    public List<UserTask> Tasks { get; private set; } = new List<UserTask>();
    
    // FK:
    public Guid? ListingId { get; init; }

    public JobApplication()
    {
        Id = Guid.NewGuid();
        SubmissionDetails = new NotSubmittedDetails(Id);
    }

    public bool HasBeenSubmitted => SubmissionDetails is SubmittedDetails;

    public void Apply(DateTime appliedDate, ApplicationChannel? channel)
    {
        var details = new SubmittedDetails(appliedDate, channel, Id);
        SubmissionDetails = details;
    }
}
