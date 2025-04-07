namespace ApplyBuddy.Domain.Aggregates.Position;

public readonly struct Salary
{
    public SalaryType Type { get; }
    public decimal Amount { get; }
    public Currency Currency { get; }

    public Salary(SalaryType type, decimal amount, Currency currency)
    {
        Type = type;
        Amount = amount;
        Currency = currency;
    }

    public override bool Equals(object? obj)
    {
        return obj is Salary other &&
               Type == other.Type &&
               Amount == other.Amount &&
               Currency == other.Currency;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Type, Amount, Currency);
    }
}
