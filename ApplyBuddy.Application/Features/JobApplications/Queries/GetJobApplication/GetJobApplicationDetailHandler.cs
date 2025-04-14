using ApplyBuddy.Application.Contracts.Persistence;
using ApplyBuddy.Application.Features.DTOs;
using ApplyBuddy.Domain.Aggregates.JobApplication;
using ApplyBuddy.Domain.Aggregates.Position;
using AutoMapper;
using MediatR;

namespace ApplyBuddy.Application.Features.JobApplications.Queries.GetJobApplication;
public class GetJobApplicationDetailHandler : IRequestHandler<GetJobApplicationDetailQuery, JobApplicationDetailVm>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<JobApplication> _applicationRepository;
    private readonly IAsyncRepository<Position> _positionRepository;

    public GetJobApplicationDetailHandler(IMapper mapper, IAsyncRepository<JobApplication> applicationRepository, IAsyncRepository<Position> positionRepository)
    {
        _mapper = mapper;
        _applicationRepository = applicationRepository;
        _positionRepository = positionRepository;
    }
    public async Task<JobApplicationDetailVm> Handle(GetJobApplicationDetailQuery request, CancellationToken cancellationToken)
    {
        var application = await _applicationRepository.GetByIdAsync(request.Id);

        if(application == null)
        {
            // TODO: Implement Not Found Exception
        }

        var applicationVm = _mapper.Map<JobApplicationDetailVm>(application);

        var position = await _positionRepository.GetByIdAsync(application.PositionId);
        applicationVm.Position = _mapper.Map<PositionDto>(position);

        return applicationVm;
    }
}
