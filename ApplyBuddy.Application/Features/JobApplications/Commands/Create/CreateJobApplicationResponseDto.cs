using ApplyBuddy.Domain.Aggregates.Listing;
using ApplyBuddy.Domain.Enums;

namespace ApplyBuddy.Application.Features.JobApplications.Commands.Create;
public record CreateJobApplicationResponseDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public Recruiter? Recruiter { get; init; }
    public ApplicationStatus Status { get; init; }
    public DateTime? AppliedDate { get; init; }
    // public PositionDto? Position { get; init; }
}
