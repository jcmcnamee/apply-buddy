using ApplyBuddy.Application.Contracts.Persistence;
using ApplyBuddy.Domain.Aggregates.JobApplication;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Application.Features.JobApplications.Commands.Delete;
public class DeleteJobApplicationHandler : IRequestHandler<DeleteJobApplicationCommand>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<JobApplication> _applicationRepository;

    public DeleteJobApplicationHandler(IMapper mapper, IAsyncRepository<JobApplication> applicationRepository)
    {
        _mapper = mapper;
        _applicationRepository = applicationRepository;
    }

    public async Task Handle(DeleteJobApplicationCommand request, CancellationToken cancellationToken)
    {
        var applicationToDelete = await _applicationRepository.GetByIdAsync(request.Id);

        if (applicationToDelete == null)
        {
            // TODO: Implement custom not found exception
        }

        await _applicationRepository.DeleteAsync(applicationToDelete);

    }
}
