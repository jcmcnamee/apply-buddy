using ApplyBuddy.Application.Contracts.Persistence;
using ApplyBuddy.Domain.Aggregates.JobApplication;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        _mapper.Map(request, applicationToUpdate, typeof(UpdateJobApplicationCommand), typeof(JobApplication));

        await _applicationRepository.UpdateAsync(applicationToUpdate);
    }
}
