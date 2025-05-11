using ApplyBuddy.Domain.Aggregates.JobApplication;
using ApplyBuddy.Domain.Aggregates.Listing;
using ApplyBuddy.Domain.Common;
using ApplyBuddy.Domain.ValueObjects;
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
    public DbSet<SubmissionDetails> SubmissionDetails => Set<SubmissionDetails>();
    public DbSet<Listing> Listings => Set<Listing>();
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<SubmissionDetails> Submissions => Set<SubmissionDetails>();
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplyBuddyDbContext).Assembly);

        // PersistenceUtilities.SeedData(modelBuilder);

    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            // TODO: Include user context
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.UtcNow;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}

