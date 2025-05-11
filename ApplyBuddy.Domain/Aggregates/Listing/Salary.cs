using ApplyBuddy.Domain.Enums;

namespace ApplyBuddy.Domain.Aggregates.Listing;

public readonly record struct Salary(
    decimal Amount,
    Currency Currency = Currency.GBP,
    SalaryType Type = SalaryType.PerAnnum
    );

