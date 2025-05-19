using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using ApplyBuddy.Server.Infrastructure;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceServices(builder.Configuration);
var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
builder.Services.AddValidatorsFromAssembly(assembly);

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
