using ApplyBuddy.Server.Domain.JobApplication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplyBuddy.Server.Infrastructure.Configurations;

public class ApplicationStateConfigurations : IEntityTypeConfiguration<ApplicationState>
{
    public void Configure(EntityTypeBuilder<ApplicationState> builder) 
    {
        builder.HasOne<JobApplication>()
            .WithOne().HasForeignKey<JobApplication>(ja => ja.StateId);
    }
}