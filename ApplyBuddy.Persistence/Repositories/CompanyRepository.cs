using ApplyBuddy.Application.Contracts.Persistence;
using ApplyBuddy.Domain.ValueObjects;

namespace ApplyBuddy.Persistence.Repositories;

public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
{
    public CompanyRepository(ApplyBuddyDbContext dbContext) : base(dbContext)
    {
    }
    
}