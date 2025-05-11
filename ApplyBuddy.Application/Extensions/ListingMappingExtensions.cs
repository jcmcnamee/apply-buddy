using ApplyBuddy.Application.Features.DTOs;
using ApplyBuddy.Domain.Aggregates.Listing;
using ApplyBuddy.Domain.Extensions;

namespace ApplyBuddy.Application.Extensions;

public static class ListingMappingExtensions
{
    public static ListingDto ToDto(this Listing listing)
    {
        return new ListingDto
        {
            Id = listing.Id,
            Status = listing.DiscoverySource.HasValue ? listing.DiscoverySource.Value.ToFriendlyString() : string.Empty,
        };
    }
}