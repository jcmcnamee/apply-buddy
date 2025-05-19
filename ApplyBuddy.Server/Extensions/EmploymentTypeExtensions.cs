using ApplyBuddy.Server.Enums;

namespace ApplyBuddy.Server.Extensions;
public static class EmploymentTypeExtensions
{
    public static string ToFriendlyString(this EmploymentType employmentType)
    {
        return employmentType switch
        {
            EmploymentType.FixedTerm => "Fixed Term Contract",
            EmploymentType.PartTime => "Part-Time",
            EmploymentType.Permanent => "Permanent",
            EmploymentType.Contract => "Contract",
            _ => throw new ArgumentOutOfRangeException(
                nameof(employmentType),
                employmentType,
                "Unhandled EmploymentType value")
        };
    }
}
