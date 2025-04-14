using ApplyBuddy.Domain.Aggregates.JobApplication;
using ApplyBuddy.Domain.Common;
using ApplyBuddy.Domain.Interfaces;

namespace ApplyBuddy.Domain.Aggregates.Position;
public class Position : AuditableEntity, IAggregateRoot
{
    public Guid Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public string? ShortDescription { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public DateTime? ListedDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Company { get; set; } = string.Empty;
    public Salary Salary { get; set; } = new(null, null, null);
    public EmploymentType? EmploymentType { get; set; }
    public PositionLevel? Level { get; set; }
}
