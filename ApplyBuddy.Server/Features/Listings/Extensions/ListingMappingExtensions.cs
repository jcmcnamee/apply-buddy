using ApplyBuddy.Server.Features.Recruiters.RecruiterMappingExtensions;
using ApplyBuddy.Server.Model.Listings;

namespace ApplyBuddy.Server.Features.Listings.Extensions;

public static class ListingMappingExtensions
{
    public static Listing ToDomainModel(CreateListing.Command command)
    {
        var listing = Listing.Create(
            position: command.Position,
            status: command.Status,
            discoverySource: command.DiscoverySource,
            listedDate: command.ListedDate,
            closingDate: command.ClosingDate
            );

        if (command.Recruiter is not null)
        {
            var recruiter = command.Recruiter.ToDomainModel();
            listing.SetRecruiter(recruiter);
        }
        
        return listing;
    }
}