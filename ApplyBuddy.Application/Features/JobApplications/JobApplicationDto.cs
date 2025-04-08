using ApplyBuddy.Application.Contracts.ApplicationServices;
using ApplyBuddy.Domain.Aggregates.JobApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Application.DTOs.JobApplications;
public class JobApplicationDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Recruiter { get; set; }
    public ApplicationStatus Status { get; set; }
    public DateTime? AppliedDate { get; set; }
    public int ActiveTasks { get; set; }
}
