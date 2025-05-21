using ApplyBuddy.Server.Domain.Common;
using ApplyBuddy.Server.Domain.Recruiters;
using ApplyBuddy.Server.Enums;

namespace ApplyBuddy.Server.Domain.Companies;

public  class Company : AuditableEntity<Guid>
{
    
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public CompanyType Type { get; set; }
    public List<Recruiter> Recruiters { get; init; } = new();
    
    private Company()
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

}