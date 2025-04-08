using ApplyBuddy.Domain.Aggregates.JobApplication;

namespace ApplyBuddy.Application.Features.JobApplications.Queries.GetJobApplicationList;

public class JobApplicationListVm
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ApplicationStatus Status { get; set; }
    public DateTime? AppliedDate { get; set; }
    public string Position { get; set; } = string.Empty;

}