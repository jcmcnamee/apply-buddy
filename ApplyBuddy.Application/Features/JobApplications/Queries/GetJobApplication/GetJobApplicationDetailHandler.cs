using ApplyBuddy.Application.Contracts.Persistence;
using ApplyBuddy.Application.Exceptions;
using ApplyBuddy.Application.Extensions;
using ApplyBuddy.Application.Features.DTOs;
using ApplyBuddy.Domain.Aggregates.JobApplication;
using ApplyBuddy.Domain.Aggregates.Listing;
using AutoMapper;
using MediatR;

namespace ApplyBuddy.Application.Features.JobApplications.Queries.GetJobApplication;
public class GetJobApplicationDetailHandler : IRequestHandler<GetJobApplicationDetailQuery, JobApplicationDetailVm>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<JobApplication> _applicationRepository;
    private readonly IAsyncRepository<Listing> _listingRepository;

    public GetJobApplicationDetailHandler(IMapper mapper, IAsyncRepository<JobApplication> applicationRepository, IAsyncRepository<Listing> positionRepository)
    {
        _mapper = mapper;
        _applicationRepository = applicationRepository;
        _listingRepository = positionRepository;
    }
    public async Task<JobApplicationDetailVm> Handle(GetJobApplicationDetailQuery request, CancellationToken cancellationToken)
    {
        var application = await _applicationRepository.GetByIdAsync(request.Id);

        if(application == null)
        {
            throw new NotFoundException(nameof(JobApplication), request.Id);
        }
        
        var listing = await _listingRepository.GetByIdAsync(application.ListingId);
        var listingSummary = listing.ToDto();
        
        var applicationVm = application.ToJobApplicationDetailVm(listingSummary);
        
        return applicationVm;
    }
}
