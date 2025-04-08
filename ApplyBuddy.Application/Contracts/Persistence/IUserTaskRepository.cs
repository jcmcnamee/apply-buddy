using ApplyBuddy.Domain.Aggregates.JobApplication;
using ApplyBuddy.Domain.Common;

namespace ApplyBuddy.Application.Contracts.Persistence;
public interface IUserTaskRepository : IAsyncRepository<UserTask>
{

}
