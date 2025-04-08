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
public class PersistenceServiceRegistration
{
    public IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EdiplanDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString
                ("EdiplanDotnetAPIConnectionString"))
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors());

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

        services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
        services.AddScoped<IPositionRepository, PositionRepository>();
        services.AddScoped<IRecruiterRepository, RecruiterRepository>();
        services.AddScoped<IApplicationTaskRepository, UserTaskRepository>();


        return services;
    }
}
