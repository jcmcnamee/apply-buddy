using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.RegularExpressions;

namespace ApplyBuddy.Server.Domain.ValueObjects;

[ComplexType]
public record PhoneNumber
{
    private PhoneNumber()
    {
    }

    private PhoneNumber(string number)
    {
        if (!string.IsNullOrWhiteSpace(number))
        {
            var cleaned = SanitiseNumber(number);

            if (!Regex.IsMatch(cleaned, @"^0\d{10,10}$"))
                throw new ArgumentException("Phone number must contain 10 digits and begin with a 0.", nameof(number));

            Number = cleaned;
        }
    }

    public string Number { get; private set; } = string.Empty;

    private static string SanitiseNumber(string number)
    {
        var sanitizedNumber = new StringBuilder();

        foreach (var c in number)
            if (char.IsDigit(c))
                sanitizedNumber.Append(c);

        return sanitizedNumber.ToString();
    }

    public static implicit operator string(PhoneNumber phoneNumber)
    {
        return phoneNumber.Number;
    }

    public static implicit operator PhoneNumber(string number)
    {
        return new PhoneNumber(number);
    }

    public override string ToString()
    {
        return Number;
    }
}