using ApplyBuddy.Domain.Aggregates.JobApplication;
using ApplyBuddy.Domain.Aggregates.Listing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplyBuddy.Domain.Enums;

namespace ApplyBuddy.Application.Features.JobApplications.Commands.Update;
public class UpdateJobApplicationCommand : IRequest
{
    public Guid Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Recruiter Recruiter { get; set; }
    public ApplicationStatus Status { get; set; }
    public DateTime AppliedDate { get; set; }
    public Guid Position { get; set; }
}
