using ApplyBuddy.Application.Contracts.Persistence;
using ApplyBuddy.Domain.Aggregates.JobApplication;
using AutoMapper;
using MediatR;

namespace ApplyBuddy.Application.Features.JobApplications.Queries.GetJobApplicationList;
public class GetJobApplicationListHandler : IRequestHandler<GetJobApplicationListQuery, List<JobApplicationListVm>>
{
    private readonly IAsyncRepository<JobApplication> _applicationRepository;
    private readonly IMapper _mapper;

    public GetJobApplicationListHandler(IMapper mapper, IAsyncRepository<JobApplication> applicationRepository)
    {
        _mapper = mapper;
        _applicationRepository = applicationRepository;
    }

    public async Task<List<JobApplicationListVm>> Handle(GetJobApplicationListQuery request, CancellationToken cancellationToken)
    {
        var allApplications = (await _applicationRepository.ListAllAsync()).OrderBy(a => a.AppliedDate);
        return _mapper.Map<List<JobApplicationListVm>>(allApplications);
    }
}
