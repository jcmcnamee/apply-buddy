using ApplyBuddy.Domain.Aggregates.Listing;
using ApplyBuddy.Domain.Enums;

namespace ApplyBuddy.Application.Features.DTOs;

public record ListingDto
{
    public Guid Id { get; init; }
    public string Status { get; init; } = string.Empty;
    public RecruiterVm? Recruiter { get; init; }
    
}