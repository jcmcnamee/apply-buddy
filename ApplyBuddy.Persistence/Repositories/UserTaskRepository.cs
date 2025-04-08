using ApplyBuddy.Application.Contracts.Persistence;
using ApplyBuddy.Domain.Aggregates.JobApplication;
using ApplyBuddy.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Persistence.Repositories;
public class UserTaskRepository : BaseRepository<UserTask>, IUserTaskRepository
{
    public UserTaskRepository(ApplyBuddyDbContext dbContext) : base(dbContext)
    {
        
    }
}
