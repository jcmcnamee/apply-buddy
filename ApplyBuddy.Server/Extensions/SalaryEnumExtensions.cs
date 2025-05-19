using ApplyBuddy.Server.Enums;

namespace ApplyBuddy.Server.Extensions;

public static class SalaryEnumExtensions
{
    public static string ToFriendlyString(this Currency currency)
    {
        return currency switch
        {
            Currency.USD => "USD",
            Currency.EUR => "EUR",
            Currency.GBP => "GBP",
            _ => throw new ArgumentException("Invalid currency")
        };
    }

    public static string ToFriendlyString(this SalaryType salaryType)
    {
        return salaryType switch
        {
            SalaryType.PerAnnum => "PerAnnum",
            SalaryType.Monthly => "ContractMonthly",
            SalaryType.Weekly => "ContractWeekly",
            SalaryType.DailyRate => "DailyRate",
            _ => throw new ArgumentException("Invalid salary type")
        };
    }
}