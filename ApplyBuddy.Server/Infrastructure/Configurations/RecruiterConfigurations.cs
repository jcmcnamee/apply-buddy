using ApplyBuddy.Server.Model.Listings;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplyBuddy.Server.Infrastructure.Configurations;
public class RecruiterConfigurations
{
    public void Configure(EntityTypeBuilder<Recruiter> builder)
    {
        builder.ComplexProperty(r => r.Details, details =>
        {
            details.ComplexProperty(d => d.PhoneNumber, phoneNumber =>
            {
                phoneNumber.Property<string>("PhoneNumber")
                    .IsRequired()
                    .HasMaxLength(20);
            });
        });
    }
}
