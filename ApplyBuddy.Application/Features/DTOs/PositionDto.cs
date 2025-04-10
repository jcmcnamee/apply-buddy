using ApplyBuddy.Domain.Aggregates.Position;

namespace ApplyBuddy.Application.Features.DTOs;
public class PositionDto
{
    public Guid Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime ListedDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Company { get; set; } = string.Empty;
    public Salary Salary { get; set; }
    public EmploymentType EmploymentType { get; set; }
    public PositionLevel Level { get; set; }
}
