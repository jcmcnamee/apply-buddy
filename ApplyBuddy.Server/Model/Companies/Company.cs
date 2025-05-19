using ApplyBuddy.Server.Enums;
using ApplyBuddy.Server.Model.Common;
using ApplyBuddy.Server.Model.Listings;

namespace ApplyBuddy.Server.Model.ValueObjects;

public sealed class Company : AuditableEntity<Guid>
{
    public Company()
    {
    }

    public Company(Guid id, string name, CompanyType type, string? description)
    {
        Id = id;
        Name = name;
        Type = type;
        if (description is not null)
            Description = description;
    }

    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public ICollection<Recruiter> Recruiters { get; init; }
}