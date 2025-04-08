using ApplyBuddy.Application.Contracts.Persistence;
using ApplyBuddy.Application.Exceptions;
using ApplyBuddy.Domain.Aggregates.JobApplication;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Application.Features.JobApplications.Commands.Create;
public class CreateJobApplicationHandler : IRequestHandler<CreateJobApplicationCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<JobApplication> _applicationRepository;

    public CreateJobApplicationHandler(IMapper mapper, IAsyncRepository<JobApplication> applicationRepository)
    {
        _mapper = mapper;
        _applicationRepository = applicationRepository;
    }

    public async Task<Guid> Handle(CreateJobApplicationCommand request, CancellationToken cancellationToken)
    {
        var application = _mapper.Map<JobApplication>(request);

        var validator = new CreateJobApplicationValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult);


        application = await _applicationRepository.AddAsync(application);

        return application.Id;

    }
}

