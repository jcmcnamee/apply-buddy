using ApplyBuddy.Application.Contracts.Persistence;
using ApplyBuddy.Domain.Aggregates.JobApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Persistence.Repositories;
internal class RecruiterRepository : BaseRepository<Recruiter>, IRecruiterRepository
{
    public RecruiterRepository(ApplyBuddyDbContext dbContext) : base(dbContext)
    {
        
    }
}
