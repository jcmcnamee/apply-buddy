using ApplyBuddy.Domain.Aggregates.Position;

namespace ApplyBuddy.Application.Contracts.Persistence;
public interface IPositionRepository : IAsyncRepository<Position>
{

}
