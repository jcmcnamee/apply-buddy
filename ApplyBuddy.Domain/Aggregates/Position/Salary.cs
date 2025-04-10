namespace ApplyBuddy.Domain.Aggregates.Position;

public record Salary(
    SalaryType? Type,
    decimal? Amount,
    Currency? Currency
    );

