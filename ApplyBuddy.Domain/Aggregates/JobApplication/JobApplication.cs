using ApplyBuddy.Domain.Common;
using ApplyBuddy.Domain.Interfaces;

namespace ApplyBuddy.Domain.Aggregates.JobApplication;
public class JobApplication : AuditableEntity, IAggregateRoot
{
    public Guid Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Recruiter? Recruiter { get; set; }
    public ApplicationStatus Status { get; private set; } = ApplicationStatus.NotApplied;
    public DateTime? AppliedDate { get; private set; }
    public List<UserTask> Tasks { get; private set; } = new List<UserTask>();
    public required Guid PositionId { get; set; }

    public int? DaysSinceApplication()
    {
        return AppliedDate.HasValue ? (int)(DateTime.UtcNow - AppliedDate.Value).TotalDays : null;
    }

    public void Apply(DateTime appliedDate)
    {
        AppliedDate = appliedDate;
        Status = ApplicationStatus.InProgress;
    }
}
