using System.ComponentModel.DataAnnotations.Schema;
using ApplyBuddy.Server.Enums;
using ApplyBuddy.Server.Model.Common;
using ApplyBuddy.Server.Model.ValueObjects;

namespace ApplyBuddy.Server.Model.Listings;
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