using ApplyBuddy.Domain.Entities;
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

    }
}
