using ApplyBuddy.Server.Enums;
using ApplyBuddy.Server.Model.ValueObjects;

namespace ApplyBuddy.Server.Model.Listings;

public record Recruiter
{
    public int Id { get; init; }
    public PersonDetails Details { get; private set; }
    public RecruiterType Type { get; private set; }
    public string? LinkedInProfile { get; private set; } = string.Empty;
    public List<Listing> Listings { get; private set; } = new();
    
    public int CompanyId { get; private set; }
    public Company Company { get; private set; }
    private Recruiter() { }
    

    public Recruiter(string name, Company company, RecruiterType type, string? profile = null)
    {
        Details = PersonDetails.Create(name);
        Company = company;
        Type = type;
        LinkedInProfile = profile;
    }
    
    public static Recruiter CreateWithIdForSeeding(int id, string name, Company company, RecruiterType type)
    {
        var details = PersonDetails.Create(name);
        
        return new Recruiter
        {
            Id = id,
            Details = details,
            Company = company,
            Type = type
        };
    }
}

//public record AgencyRecruiter(string Agency) : Recruiter

