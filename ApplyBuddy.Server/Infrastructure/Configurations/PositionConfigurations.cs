using ApplyBuddy.Server.Model.Listings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplyBuddy.Server.Infrastructure.Configurations;

public class PositionConfigurations : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.Property<int>("Id").ValueGeneratedOnAdd();
        builder.HasKey("Id");
        builder.ToTable("Positions");
        builder.ComplexProperty(p => p.Salary);
    }
}