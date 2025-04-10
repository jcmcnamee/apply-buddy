using ApplyBuddy.Application.Contracts.Persistence;
using ApplyBuddy.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Persistence;
public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplyBuddyDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString
                ("ApplyBuddyConnectionString"))
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors());

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

        services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
        services.AddScoped<IPositionRepository, PositionRepository>();
        services.AddScoped<IRecruiterRepository, RecruiterRepository>();
        services.AddScoped<IUserTaskRepository, UserTaskRepository>();


        return services;
    }
}
