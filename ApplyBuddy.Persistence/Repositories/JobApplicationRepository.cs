using ApplyBuddy.Application.Contracts.Persistence;
using ApplyBuddy.Domain.Aggregates.JobApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplyBuddy.Domain.Enums;

namespace ApplyBuddy.Persistence.Repositories;
internal class JobApplicationRepository : BaseRepository<JobApplication>, IJobApplicationRepository
{
    public JobApplicationRepository(ApplyBuddyDbContext dbContext) : base(dbContext)
    {

    }

    public Task<bool> IsJobApplicationNameAndDateUnique(string name, DateTime appliedDate)
    {
        var matches = _dbContext.Applications
            .Any(a => a.HasBeenSubmitted &&
                      ((SubmittedDetails)a.SubmissionDetails).AppliedDate.Equals(appliedDate)
            );
        return Task.FromResult(matches);
    }

    public Task<List<JobApplicationListDto>> ListAllJobApplicationsAsync()
    {
        
    }

    // public async Task<List<JobApplication>> GetApplicationsWithRecruiters
}

public record JobApplicationListDto<TDetails> where TDetails : SubmissionDetails
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string TruncatedDescription { get; init; } = string.Empty;
    public required TDetails SubmissionDetails { get; init; }
    public int ActiveTasks { get; init; }
    
    // From Listing Aggregate
    public DateTime? ListingClosingDate { get; init; }
    public string PositionName { get; init; } = string.Empty;
    public PositionLevel PositionLevel { get; init; }
    public string CompanyName { get; init; } = string.Empty;
}
