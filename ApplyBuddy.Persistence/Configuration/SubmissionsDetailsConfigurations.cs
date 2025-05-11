using ApplyBuddy.Domain.Aggregates.JobApplication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplyBuddy.Persistence.Configuration;

public class SubmissionsDetailsConfigurations : IEntityTypeConfiguration<SubmissionDetails>
{
    public void Configure(EntityTypeBuilder<SubmissionDetails> builder)
    {
        builder.HasDiscriminator<string>("details_type")
            .HasValue<NotSubmittedDetails>("not_submitted")
            .HasValue<SubmittedDetails>("submitted");
    }
}

// public class SubmittedDetailsConfigurations : IEntityTypeConfiguration<SubmittedDetails>
// {
//     public void Configure(EntityTypeBuilder<SubmittedDetails> builder)
//     {
//         
//     }
// }
//
// public class NotSubmittedDetailsConfigurations : IEntityTypeConfiguration<NotSubmittedDetails>
// {
//     public void Configure(EntityTypeBuilder<NotSubmittedDetails> builder)
//     {
//         
//     }
// }