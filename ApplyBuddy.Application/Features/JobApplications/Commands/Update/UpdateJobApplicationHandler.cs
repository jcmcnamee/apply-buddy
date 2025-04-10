using ApplyBuddy.Application.Contracts.Persistence;
using ApplyBuddy.Domain.Aggregates.JobApplication;
using AutoMapper;
using MediatR;

namespace ApplyBuddy.Application.Features.JobApplications.Commands.Update;
public class UpdateJobApplicationHandler : IRequestHandler<UpdateJobApplicationCommand>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<JobApplication> _applicationRepository;

    public UpdateJobApplicationHandler(IMapper mapper, IAsyncRepository<JobApplication> applicationRepository)
    {
        _mapper = mapper;
        _applicationRepository = applicationRepository;
    }

    public async Task Handle(UpdateJobApplicationCommand request, CancellationToken cancellationToken)
    {
        var applicationToUpdate = await _applicationRepository.GetByIdAsync(request.Id);

        if (applicationToUpdate == null)
        {
            // TODO: Implement custom not found exception
        }

        _mapper.Map(request, applicationToUpdate, typeof(UpdateJobApplicationCommand), typeof(JobApplication));

        await _applicationRepository.UpdateAsync(applicationToUpdate);
    }
}
