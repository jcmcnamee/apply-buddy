using ApplyBuddy.Domain.Aggregates.JobApplication;
using ApplyBuddy.Domain.Aggregates.Listing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplyBuddy.Domain.Enums;

namespace ApplyBuddy.Application.Features.JobApplications.Commands.Create;
public class CreateJobApplicationCommand : IRequest<CreateJobApplicationResponse>
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public Recruiter? Recruiter { get; set; }
    public ApplicationStatus Status { get; set; } = ApplicationStatus.NotApplied;
    public DateTime? AppliedDate { get;  set; }
    public List<UserTask>? Tasks { get; set; } = new List<UserTask>();
    public Guid? Position { get; set; }

    public override string ToString()
    {
        return $"Application name: {Name}; Position: {Position}; Description: {Description}; Status: {Status}; Applied: {AppliedDate}";
    }
}
