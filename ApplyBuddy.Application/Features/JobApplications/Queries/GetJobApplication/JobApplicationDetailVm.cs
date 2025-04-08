using ApplyBuddy.Application.Features.DTOs;
using ApplyBuddy.Domain.Aggregates.JobApplication;

namespace ApplyBuddy.Application.Features.JobApplications.Queries.GetJobApplication;
public class JobApplicationDetailVm
{
    public Guid Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Recruiter? Recruiter { get; set; }
    public ApplicationStatus Status { get; set; }
    public DateTime? AppliedDate { get; set; }
    public List<TaskListDto> Tasks { get; set; } = new();
    public PositionDto Position { get; set; } = new();
}
