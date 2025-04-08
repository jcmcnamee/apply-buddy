namespace ApplyBuddy.Domain.Aggregates.JobApplication;

public record Recruiter
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public PersonTitle? Title { get; init; }
    public string? PhoneNumber { get; init; } = string.Empty;
    public string? Agency { get; init; } = string.Empty;
    public string? LinkedInProfile { get; init; } = string.Empty;

    public Recruiter(string name, PersonTitle? title, string? phoneNumber, string? agency, string linkedIn)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid name string given.");
        Name = name;
        Title = title;
        PhoneNumber = phoneNumber;
        Agency = agency;
        LinkedInProfile = linkedIn;
    }

}
