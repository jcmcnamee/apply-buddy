using ApplyBuddy.Server.Domain.Listings;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplyBuddy.Server.Infrastructure.Configurations;

public class ListingConfigurations
{
    public void Configure(EntityTypeBuilder<Listing> builder)
    {
        builder.ComplexProperty(l => l.DiscoverySource);
    }

}