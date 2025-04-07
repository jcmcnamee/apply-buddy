using System.Net;
using System.Runtime.CompilerServices;

namespace ApplyBuddy.Application.Services;

// Communicates between Controllers to business rules/use cases
public interface IMediator
{
    TResponse Send<TResponse>(IRequest<TResponse> request);
}

