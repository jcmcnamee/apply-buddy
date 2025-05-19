using ApplyBuddy.Server.Model.Listings;
using ApplyBuddy.Server.Model.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplyBuddy.Server.Infrastructure.Configurations;

public class ListingConfigurations
{
    public void Configure(EntityTypeBuilder<Listing> builder)
    {
        builder.ComplexProperty(l => l.DiscoverySource);
    }

}