using ApplyBuddy.Domain.Common;
using ApplyBuddy.Domain.Enums;
using ApplyBuddy.Domain.ValueObjects;

namespace ApplyBuddy.Domain.Aggregates.Listing;
public record Position
{
    public required string Name { get; init; }
    public string? Location { get; init; } = string.Empty;
    public string? Description { get; init; } = string.Empty;
    public Company? Company { get; init; }
    public Salary? Salary { get; init; }
    public EmploymentType? EmploymentType { get; init; }
    public PositionLevel? Level { get; init; }
}



