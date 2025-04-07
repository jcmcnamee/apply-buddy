namespace ApplyBuddy.Domain.Aggregates.JobApplication;

public static class ApplicationStatusExtensions
{
    public static string ToFriendlyString(this ApplicationStatus status)
    {
        return status switch
        {
            ApplicationStatus.NotApplied => "Not applied",
            ApplicationStatus.InProgress => "In progress",
            ApplicationStatus.Rejected => "Rejected",
            ApplicationStatus.Success => "Success",
            _ => throw new ArgumentException("Invalid application status")
        };
    }
}
