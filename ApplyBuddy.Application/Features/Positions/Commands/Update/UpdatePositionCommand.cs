using ApplyBuddy.Domain.Aggregates.Position;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Application.Features.Positions.Commands.Update;
public class UpdatePositionCommand : IRequest
{
    public Guid Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public string? ShortDescription { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public DateTime? ListedDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsActive { get; set; }
    public string? Company { get; set; } = string.Empty;
    public Salary? Salary { get; set; }
    public EmploymentType? EmploymentType { get; set; }
    public PositionLevel? Level { get; set; }
}
