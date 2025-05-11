using ApplyBuddy.Domain.Aggregates.JobApplication;
using ApplyBuddy.Domain.Enums;

namespace ApplyBuddy.Application.Features.JobApplications.Queries.GetJobApplicationList;

public record JobApplicationListVm
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Status { get; init; } = string.Empty;
    public DateTime? AppliedDate { get; init; }
    public DateTime? CreatedDate { get; init; }
    public DateTime? ListingCloseDate { get; init; }
    public string Position { get; init; } = string.Empty;
    public string PositionLevel { get; init; } = string.Empty;
    public int TaskCount { get; init; }
}