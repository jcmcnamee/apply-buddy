using ApplyBuddy.Application;
using ApplyBuddy.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ApplyBuddy.Api;

public static class StartupExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddApplicationServices();
        builder.Services.AddPersistenceServices(builder.Configuration);

        builder.Services.AddControllers();

        builder.Services.AddCors(
            opts => opts.AddPolicy(
                "open",
                policy => policy.WithOrigins([builder.Configuration["ApiUrl"] ??
                "https://localhost:7020",
                builder.Configuration["ReactUrl"] ??
                "https://localhost:7080"])
                .AllowAnyMethod()
                .SetIsOriginAllowed(pol => true)
                .AllowAnyHeader()
                .AllowCredentials()));

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseCors("open");
        app.UseHttpsRedirection();
        app.MapControllers();

        return app;
    }

    public static async Task ResetDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        try
        {
            var context = scope.ServiceProvider.GetService<ApplyBuddyDbContext>();
            if(context != null)
            {
                await context.Database.EnsureDeletedAsync();
                await context.Database.MigrateAsync();
                await DbSeeder.SeedAsync(context);
            }
        }
        catch (Exception ex)
        {
            // TODO: Add logging here.
        }
    }
}
