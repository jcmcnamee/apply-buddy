using ApplyBuddy.Server.Model.Listings;
using ApplyBuddy.Server.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplyBuddy.Server.Infrastructure.Configurations;

public class ChannelConfigurations : IEntityTypeConfiguration<Channel>
{
    public void Configure(EntityTypeBuilder<Channel> builder)
    {
        // builder.Property<int>("Id").ValueGeneratedOnAdd();
        // builder.HasKey("Id");

        // builder.HasOne<Recruiter>()
        //     .WithOne()
        //     .HasForeignKey<Channel>(c => c.RecruiterId);
        //
        // builder.HasOne<Company>()
        //     .WithOne()
        //     .HasForeignKey<Channel>(c => c.CompanyId);
    }
}