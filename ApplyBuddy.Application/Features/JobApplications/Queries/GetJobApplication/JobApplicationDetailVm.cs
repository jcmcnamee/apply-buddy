using ApplyBuddy.Application.Features.DTOs;
using ApplyBuddy.Domain.Aggregates.JobApplication;
using ApplyBuddy.Domain.Aggregates.Listing;

namespace ApplyBuddy.Application.Features.JobApplications.Queries.GetJobApplication;
public record JobApplicationDetailVm
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public required SubmissionDetails SubmissionDetails { get; init; }
    public ListingDto Listing { get; init; } = new();
    public List<TaskListDto> Tasks { get; init; } = new();
}
