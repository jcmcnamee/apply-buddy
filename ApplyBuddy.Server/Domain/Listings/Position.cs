using ApplyBuddy.Server.Domain.Common;
using ApplyBuddy.Server.Domain.Companies;
using ApplyBuddy.Server.Enums;

namespace ApplyBuddy.Server.Domain.Listings;
public record Position : ValueObject
{
    public required string Name { get; init; }
    public string? Location { get; init; } = string.Empty;
    public string? Description { get; init; } = string.Empty;
    public Salary Salary { get; init; } = null!;
    public EmploymentType? EmploymentType { get; init; }
    public PositionLevel? Level { get; init; }
    public Company? Company { get; init; }
}