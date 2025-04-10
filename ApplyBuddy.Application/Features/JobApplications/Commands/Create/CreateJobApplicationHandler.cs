using ApplyBuddy.Application.Contracts.Persistence;
using ApplyBuddy.Domain.Aggregates.JobApplication;
using AutoMapper;
using MediatR;

namespace ApplyBuddy.Application.Features.JobApplications.Commands.Create;
public class CreateJobApplicationHandler : IRequestHandler<CreateJobApplicationCommand, CreateJobApplicationResponse>
{
    private readonly IMapper _mapper;
    private readonly IJobApplicationRepository _applicationRepository;

    public CreateJobApplicationHandler(IMapper mapper, IJobApplicationRepository applicationRepository)
    {
        _mapper = mapper;
        _applicationRepository = applicationRepository;
    }

    public async Task<CreateJobApplicationResponse> Handle(CreateJobApplicationCommand request, CancellationToken cancellationToken)
    {
        var response = new CreateJobApplicationResponse();
        var validator = new CreateJobApplicationValidator(_applicationRepository);

        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
        {
            response.Success = false;
            response.ValidationErrors = new List<string>();

            foreach (var error in validationResult.Errors)
            {
                response.ValidationErrors.Add(error.ErrorMessage);
            }
        }

        if (response.Success)
        {
            var application = _mapper.Map<JobApplication>(request);
            application = await _applicationRepository.AddAsync(application);
            response.JobApplication = _mapper.Map<CreateJobApplicationResponseDto>(application);
        }

        return response;

    }
}

