using ApplyBuddy.Server.Domain.Listings;
using ApplyBuddy.Server.Features.Recruiters.RecruiterMappingExtensions;

namespace ApplyBuddy.Server.Features.Listings.Extensions;

public static class ListingMappingExtensions
{
    public static Listing ToDomainModel(CreateListing.CreateListingCommand createListingCommand)
    {
        var listing = Listing.Create(
            position: createListingCommand.Position,
            status: createListingCommand.Status,
            discoverySource: createListingCommand.DiscoverySource,
            listedDate: createListingCommand.ListedDate,
            closingDate: createListingCommand.ClosingDate
            );

        if (createListingCommand.Recruiter is not null)
        {
            var recruiter = createListingCommand.Recruiter.ToDomainModel();
            listing.SetRecruiter(recruiter);
        }
        
        return listing;
    }
}