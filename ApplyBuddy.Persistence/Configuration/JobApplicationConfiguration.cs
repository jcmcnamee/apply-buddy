using ApplyBuddy.Domain.Aggregates.JobApplication;
using ApplyBuddy.Domain.Aggregates.Listing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplyBuddy.Persistence.Configuration;
public class JobApplicationConfiguration : IEntityTypeConfiguration<JobApplication>
{
    public void Configure(EntityTypeBuilder<JobApplication> builder)
    {
        // Prperties
        builder.Property(j => j.Name)
            .IsRequired()
            .HasMaxLength(50);
        
        // Conversions
        builder.Property(j => j.CreatedDate)
            .HasConversion(
                d => d.ToUniversalTime(),
                d => d.ToUniversalTime()
                );
        
        builder.Property(j => j.LastModifiedDate)
            .HasConversion(
                d => d.Value.ToUniversalTime(),
                d => d.ToUniversalTime()
                );

        // Navigations and relations
        builder.HasOne<Listing>()
            .WithOne()
            .HasForeignKey<JobApplication>(ja => ja.ListingId);
        
        builder.HasOne(ja => ja.SubmissionDetails)
            .WithOne()
            .HasForeignKey<SubmissionDetails>(sd => sd.ApplicationId)
            .IsRequired();
    }
}
