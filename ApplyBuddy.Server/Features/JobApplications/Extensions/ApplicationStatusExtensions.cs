using ApplyBuddy.Server.Enums;

namespace ApplyBuddy.Server.Features.JobApplications.Extensions;

public static class ApplicationStatusExtensions
{
    public static string ToFriendlyString(this ApplicationState state)
    {
        return state switch
        {
            ApplicationState.NotApplied => "Not applied",
            ApplicationState.InProgress => "In progress",
            ApplicationState.Rejected => "Rejected",
            ApplicationState.Success => "Success",
            _ => throw new ArgumentException("Invalid application status")
        };
    }
}
