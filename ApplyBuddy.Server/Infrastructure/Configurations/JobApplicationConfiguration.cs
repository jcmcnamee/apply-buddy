using ApplyBuddy.Server.Domain.JobApplication;
using ApplyBuddy.Server.Domain.Listings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplyBuddy.Server.Infrastructure.Configurations;
public class JobApplicationConfiguration : IEntityTypeConfiguration<JobApplication>
{
    public void Configure(EntityTypeBuilder<JobApplication> builder)
    {
        // Properties
        builder.Property(ja => ja.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(ja => ja.Notes)
            .HasColumnType("text")
            .HasMaxLength(4000);

        builder.ComplexProperty(ja => ja.Channel);
        
        // Conversions
        builder.Property(ja => ja.CreatedDate)
            .HasConversion(
                d => d.ToUniversalTime(),
                d => d.ToUniversalTime()
                );
        
        builder.Property(ja => ja.LastModifiedDate)
            .HasConversion(
                d => d.Value.ToUniversalTime(),
                d => d.ToUniversalTime()
                );

        // Navigations and relations
        builder.HasOne<Listing>()
            .WithOne()
            .HasForeignKey<JobApplication>(ja => ja.ListingId);
        
    }
}
