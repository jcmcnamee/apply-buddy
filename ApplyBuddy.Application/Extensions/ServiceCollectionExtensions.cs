using ApplyBuddy.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ApplyBuddy.Application.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMediator(this IServiceCollection services, Assembly assembly)
    {
        // Register the Mediator
        services.AddTransient<IMediator, Mediator>();

        // Scan the assembly for types implementing IRequestHandler<,>
        var handlerInterfaceType = typeof(IRequestHandler<,>);

        var types = assembly.GetTypes()
            .Where(type => !type.IsAbstract && !type.IsInterface)
            .SelectMany(type => type.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterfaceType)
                .Select(i => new { HandlerInterface = i, Implementation = type }));

        // Get interfaces

        // Select all those interfaces that match the handerler interface type

        // Store each interface and implementation to register

        foreach (var type in types)
        {
            services.AddTransient(type.HandlerInterface, type.Implementation);
        }

        return services;
    }
}