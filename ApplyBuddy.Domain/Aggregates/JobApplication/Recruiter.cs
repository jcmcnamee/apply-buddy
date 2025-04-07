namespace ApplyBuddy.Domain.Aggregates.JobApplication;

public class Recruiter
{
    public string Name { get; } = string.Empty;
    public PersonTitle? Title { get; }
    public string? PhoneNumber { get; } = string.Empty;
    public string? Agency { get; } = string.Empty;
    public string? LinkedInProfile { get; } = string.Empty;

    public Recruiter(string name, PersonTitle? title, string? phoneNumber, string? agency, string linkedIn)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid name string given.");
        Name = name;
        Title = title;
        PhoneNumber = phoneNumber;
        Agency = agency;
        LinkedInProfile = linkedIn;
    }

    public override bool Equals(object? obj)
    {
        return obj is Recruiter other &&
               Name == other.Name &&
               Title == other.Title &&
               PhoneNumber == other.PhoneNumber &&
               Agency == other.Agency;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Title, PhoneNumber, Agency);
    }

}
