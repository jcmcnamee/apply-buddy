using System.Reflection.Metadata;
using ApplyBuddy.Server.Domain.Common;
using ApplyBuddy.Server.Domain.Companies;
using ApplyBuddy.Server.Domain.Documents;
using ApplyBuddy.Server.Domain.JobApplication;
using ApplyBuddy.Server.Domain.Listings;
using ApplyBuddy.Server.Domain.Recruiters;
using ApplyBuddy.Server.Domain.ValueObjects;
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

    public DbSet<Channel> Channels => Set<Channel>();
    public DbSet<DocumentRecord> Documents => Set<DocumentRecord>();

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
