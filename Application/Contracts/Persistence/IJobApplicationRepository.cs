using ApplyBuddy.Domain.Entities;

namespace ApplyBuddy.Application.Contracts.Persistence;

public interface IJobApplicationRepository : IAsyncRepository<JobApplication>
{
    public Task<bool> IsJobApplicationNameAndDateUnique(string name, DateTime appliedDate);
}
