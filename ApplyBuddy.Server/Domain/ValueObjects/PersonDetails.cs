using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace ApplyBuddy.Server.Domain.ValueObjects;

[ComplexType]
public record PersonDetails
{
    // For EF Core
    private PersonDetails()
    {
    }

    // Private constructor with all possible parameters
    private PersonDetails(string firstName, string? lastName, string? email, string? phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        if (phoneNumber != null)
            PhoneNumber = phoneNumber;
    }

    public string FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string? Email { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; } = string.Empty;
    
    public string FullName => LastName == null ? FirstName : $"{FirstName} {LastName}";
    
    public static PersonDetails Create(string name)
    {
        var (first, last) = ParseAndValidateName(name);
        return new PersonDetails
        {
            FirstName = first,
            LastName = last,
            Email = null,
            PhoneNumber = string.Empty
        };
    }

    // Validation methods
    private static string ValidateEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email cannot be null or whitespace.", nameof(email));
        
        var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
        if (!regex.IsMatch(email))
            throw new ArgumentException($"'{email}' is not a valid email address.", nameof(email));

        return email;
    }

    private static (string firstName, string? lastName) ParseAndValidateName(string name)
    {
        if (name is null)
            throw new ArgumentNullException(nameof(name), "Name cannot be null.");

        var trimmedName = name.Trim();
        var split = trimmedName.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (split.Length == 0)
            throw new ArgumentException("Name cannot be empty.", nameof(name));

        var firstName = split[0];
        var lastName = split.Length > 1 ? string.Join(" ", split.Skip(1)) : null;

        return (firstName, lastName);
    }
}