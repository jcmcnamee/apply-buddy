using Microsoft.EntityFrameworkCore;

namespace ApplyBuddy.Server.Infrastructure;
public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplyBuddyDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString
                ("ApplyBuddyConnectionString"))
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors());

        // services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
        //
        // services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
        // services.AddScoped<IListingRepository, ListingRepository>();
        // services.AddScoped<ICompanyRepository, CompanyRepository>();
        // services.AddScoped<IRecruiterRepository, RecruiterRepository>();
        // services.AddScoped<ISubmissionsRepository, SubmissionsRepository>();
        // services.AddScoped<IUserTaskRepository, UserTaskRepository>();

        return services;
    }
}
