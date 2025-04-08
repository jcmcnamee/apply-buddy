namespace ApplyBuddy.Application.Utilities;

public interface IMapper
{
    TDestination Map<TDestination>(object source);
}