namespace ApplyBuddy.Domain.Aggregates.Position;

public static class EmploymentTypeExtensions
{
    public static string ToFriendlyString(this EmploymentType type)
    {
        return type switch
        {
            EmploymentType.FixedTerm => "Fixed Term Contract",
            EmploymentType.PartTime => "Part-Time",
            EmploymentType.Permanent => "Permanent",
            EmploymentType.Contract => "Contract",
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
