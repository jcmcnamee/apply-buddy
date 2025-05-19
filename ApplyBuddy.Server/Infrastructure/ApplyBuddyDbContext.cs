using ApplyBuddy.Server.Model.Common;
using ApplyBuddy.Server.Model.JobApplication;
using ApplyBuddy.Server.Model.Listings;
using ApplyBuddy.Server.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ApplyBuddy.Server.Infrastructure;

public class ApplyBuddyDbContext : DbContext
{
    public ApplyBuddyDbContext()
    {
    }

    public ApplyBuddyDbContext(DbContextOptions<ApplyBuddyDbContext> options)
        : base(options)
    {
    }
    public DbSet<JobApplication> Applications => Set<JobApplication>();
    public DbSet<Listing> Listings => Set<Listing>();
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Recruiter> Recruiters => Set<Recruiter>();
    // public DbSet<SubmissionDetails> Submissions => Set<SubmissionDetails>();
    public DbSet<Channel> Channels => Set<Channel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplyBuddyDbContext).Assembly);
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
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
