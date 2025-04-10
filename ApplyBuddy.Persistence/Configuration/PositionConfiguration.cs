using ApplyBuddy.Domain.Aggregates.Position;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplyBuddy.Persistence.Configuration;
public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.ComplexProperty(p => p.Salary);

        builder.Property(j => j.CreatedDate)
            .HasConversion(
                d => d.ToUniversalTime(),
                d => d.ToUniversalTime()
            );

        builder.Property(j => j.ListedDate)
            .HasConversion(
                d => d.Value.ToUniversalTime(),
                d => d.ToUniversalTime()
            );

        builder.Property(j => j.EndDate)
            .HasConversion(
                d => d.Value.ToUniversalTime(),
                d => d.ToUniversalTime()
            );


    }
}
