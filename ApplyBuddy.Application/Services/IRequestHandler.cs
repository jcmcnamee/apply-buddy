namespace ApplyBuddy.Application.Services;

// Colleague making sure type constraint allow return of derived request types
public interface IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    void Handle(TRequest request);

}

