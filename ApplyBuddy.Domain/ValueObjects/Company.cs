using ApplyBuddy.Domain.Common;
using ApplyBuddy.Domain.Enums;

namespace ApplyBuddy.Domain.ValueObjects;

public sealed class Company: AuditableEntity<int>
{
    public string Name { get; init; } = string.Empty;
    public CompanyType Type { get; init; }
    public string Description { get; init; } = string.Empty;

    public Company(string name, CompanyType type, string? description) : base()
    {
           Name = name;
           Type = type;
           if (description is not null)
               Description = description;
    }
}