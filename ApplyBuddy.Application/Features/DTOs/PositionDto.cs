using ApplyBuddy.Domain.Aggregates.Listing;
using ApplyBuddy.Domain.Common;
using ApplyBuddy.Domain.Enums;

namespace ApplyBuddy.Application.Features.DTOs;
public record PositionDto
{
    public string Name { get; init; } = string.Empty;
    public string? Description { get; init; } = string.Empty;
    public string? Company { get; init; } = string.Empty;
    public string? Location { get; init; } = string.Empty;
    public SalaryVm? Salary { get; init; }
    public string? EmploymentType { get; init; } = string.Empty;
    public string? Level { get; init; } = string.Empty;
}
