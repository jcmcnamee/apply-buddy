namespace ApplyBuddy.Application.Features.DTOs;

public readonly record struct SalaryVm(decimal Amount)
{
    public decimal Amount { get; init; }
    public string Currency { get; init; } = string.Empty;
    public string Type { get; init; } = string.Empty;
}