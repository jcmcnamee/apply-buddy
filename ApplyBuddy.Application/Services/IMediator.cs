namespace ApplyBuddy.Application.Services;

public interface IMediator
{
    TResponse Send<TResponse>(IRequest<TResponse> request);
}