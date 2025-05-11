using ApplyBuddy.Domain.Aggregates.Listing;

namespace ApplyBuddy.Application.Contracts.Persistence;

public interface IListingRepository : IAsyncRepository<Listing>
{
    
}