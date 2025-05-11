namespace ApplyBuddy.Application.Features.DTOs;

public record RecruiterVm()
{
    public string Name { get; init; } = string.Empty;
    public string? Email { get; init; } = string.Empty;
    public string? Phone { get; init; } = string.Empty;
    public string? LinkedIn { get; init; } = string.Empty;
    public string? Type { get; init; } = string.Empty;
    public string? Company { get; init; } = string.Empty;
}