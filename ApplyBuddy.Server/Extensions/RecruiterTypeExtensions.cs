using ApplyBuddy.Server.Enums;

namespace ApplyBuddy.Server.Extensions;

public static class RecruiterTypeExtensions
{
    public static string ToFriendlyString(this RecruiterType type)
    {
        return type switch
        {
            RecruiterType.Internal => "Internal",
            RecruiterType.Agency => "Agency",
            _ => throw new ArgumentException("Invalid recruiter type")
        };
    }
}