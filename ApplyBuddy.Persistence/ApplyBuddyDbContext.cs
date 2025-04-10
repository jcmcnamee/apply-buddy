using ApplyBuddy.Domain.Aggregates.JobApplication;
using ApplyBuddy.Domain.Aggregates.Position;
using ApplyBuddy.Domain.Common;
using ApplyBuddy.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApplyBuddy.Persistence;

public class ApplyBuddyDbContext : DbContext
{
    public ApplyBuddyDbContext(DbContextOptions<ApplyBuddyDbContext> options)
         : base(options)
    {
    }

    public DbSet<JobApplication> Applications => Set<JobApplication>();
    public DbSet<Position> Positions => Set<Position>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplyBuddyDbContext).Assembly);

        // PersistenceUtilities.SeedData(modelBuilder);

    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}

