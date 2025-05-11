using ApplyBuddy.Application.Contracts.Persistence;
using ApplyBuddy.Domain.Aggregates.Listing;

namespace ApplyBuddy.Persistence.Repositories;

public class ListingRepository : BaseRepository<Listing>, IListingRepository
{
    public ListingRepository(ApplyBuddyDbContext dbContext) : base(dbContext)
    {
    }
    
    
}