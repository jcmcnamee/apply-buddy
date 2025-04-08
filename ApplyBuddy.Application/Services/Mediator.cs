using System.Net;
using System.Runtime.CompilerServices;

namespace ApplyBuddy.Application.Services;

// Communicates between Controllers to business rules/use cases

public class Mediator : IMediator
{

    private readonly IServiceProvider _serviceProvider;

    public Mediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public TResponse Send<TResponse>(IRequest<TResponse> request)
    {
        // Get request type
        var requestType = request.GetType();

        // Create the handler type
        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(requestType, typeof(TResponse));

        // Get the handler from serivce provider:
        var handler = _serviceProvider.GetService(handlerType);

        // Get the Handle method
        var method = handlerType.GetMethod("Handle");

        // Invoke handle method and return the response
        return (TResponse)method.Invoke(handler, new object[] { request });
    }
}
