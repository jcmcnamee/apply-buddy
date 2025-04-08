using ApplyBuddy.Application.Contracts.Persistence;
using ApplyBuddy.Domain.Aggregates.Position;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Persistence.Repositories;
public class PositionRepository : BaseRepository<Position>, IPositionRepository
{
    public PositionRepository(ApplyBuddyDbContext dbContext) : base(dbContext)
    {
        
    }
}
