using ApplyBuddy.Server.Domain.JobApplication;

namespace ApplyBuddy.Server.Features.JobApplications.Extensions;

public static class JobApplicationMappingExtensions
{
    public static JobApplication ToDomainModel(this CreateJobApplication.CreateJobApplicationCommand createJobApplicationCommand)
    {
        return JobApplication.Create(
            createJobApplicationCommand.Name,
            createJobApplicationCommand.Notes,
            createJobApplicationCommand.ListingId
            );
    }
}