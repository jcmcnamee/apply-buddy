using ApplyBuddy.Domain.Common;
using ApplyBuddy.Domain.ValueObjects;

namespace ApplyBuddy.Application.Contracts.Persistence;

public interface ICompanyRepository : IAsyncRepository<Company>
{
    
}