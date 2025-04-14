using ApplyBuddy.Domain.Aggregates.JobApplication;
using ApplyBuddy.Domain.Aggregates.Position;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplyBuddy.Persistence.Configuration;
public class JobApplicationConfiguration : IEntityTypeConfiguration<JobApplication>
{
    public void Configure(EntityTypeBuilder<JobApplication> builder)
    {
        builder.Property(j => j.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(j => j.AppliedDate)
            .HasConversion(
                d => d.Value.ToUniversalTime(),
                d => d.ToUniversalTime()
                );

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

        builder.HasOne<Position>()
            .WithOne()
            .HasForeignKey<JobApplication>(j => j.PositionId)
            .IsRequired();

    }
}
