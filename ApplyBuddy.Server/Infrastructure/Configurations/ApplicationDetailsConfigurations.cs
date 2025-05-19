using ApplyBuddy.Server.Model.JobApplication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplyBuddy.Server.Infrastructure.Configurations;

public class ApplicationDetailsConfigurations : IEntityTypeConfiguration<ApplicationDetails>
{
    public void Configure(EntityTypeBuilder<ApplicationDetails> builder) 
    {
        builder.ToTable("Submissions");
        builder.HasDiscriminator<string>("details_type")
            .HasValue<OpenApplicationDetails>("not_submitted")
            .HasValue<ClosedApplicationDetails>("submitted");
    }
}