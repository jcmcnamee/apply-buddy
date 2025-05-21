namespace ApplyBuddy.Server.Domain.Common;

public class BaseEntity<TId>
{
    public required TId Id { get; init; }

    // public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
}