using ApplyBuddy.Application.Contracts.Persistence;
using ApplyBuddy.Domain.Aggregates.JobApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Persistence.Repositories;
internal class JobApplicationRepository : BaseRepository<JobApplication>, IJobApplicationRepository
{
    public JobApplicationRepository(ApplyBuddyDbContext dbContext) : base(dbContext)
    {

    }

    public Task<bool> IsJobApplicationNameAndDateUnique(string name, DateTime appliedDate)
    {
        var matches = _dbContext.Applications.Any(a => a.Name.Equals(name) && a.AppliedDate.Equals(appliedDate));
        return Task.FromResult(matches);
    }

    public async Task<List<JobApplication>> GetApplicationsWithRecruiters
}
