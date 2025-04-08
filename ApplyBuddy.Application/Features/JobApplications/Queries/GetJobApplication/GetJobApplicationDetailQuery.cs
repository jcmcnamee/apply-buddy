using MediatR;

namespace ApplyBuddy.Application.Features.JobApplications.Queries.GetJobApplication;
public class GetJobApplicationDetailQuery : IRequest<JobApplicationDetailVm>
{
    public Guid Id { get; init; }
}
