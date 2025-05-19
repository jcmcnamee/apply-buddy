using System.ComponentModel.DataAnnotations.Schema;
using ApplyBuddy.Server.Enums;

namespace ApplyBuddy.Server.Model.Listings;

//public readonly record struct Salary(
//    decimal Amount,
//    Currency Currency = Currency.GBP,
//    SalaryType Type = SalaryType.PerAnnum
//    );

[ComplexType]
public record Salary
{
    public decimal Amount { get; init; }
    public Currency Currency { get; init; } = Currency.GBP;
    public SalaryType Type { get; init; } = SalaryType.PerAnnum;
    public Salary()
    {
    }
}

