using ApplyBuddy.Server.Model.JobApplication;

namespace ApplyBuddy.Server.Features.JobApplications.Extensions;

public static class JobApplicationMappingExtensions
{
    public static JobApplication ToDomainModel(this CreateJobApplication.Command command)
    {
        return JobApplication.Create(
            command.Name,
            command.Notes,
            command.ListingId
            );
    }
}