namespace ApplyBuddy.Domain.Common;

public class BaseEntity<TId>
{
    public TId Id { get; protected set; }
    
    // public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
}