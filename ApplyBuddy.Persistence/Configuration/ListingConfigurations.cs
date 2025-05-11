using ApplyBuddy.Domain.Aggregates.Listing;
using ApplyBuddy.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplyBuddy.Persistence.Configuration;

public class ListingConfigurations
{
    public void Configure(EntityTypeBuilder<Listing> builder)
    {
        // builder
        //     .OwnsOne(l => l.Recruiter)
        //     .HasOne<Company>().WithOne()
        //     .HasForeignKey<Recruiter>(r => r.CompanyId);

        builder.ComplexProperty(l => l.Recruiter);
    }
}