using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Domain.Entities;
public class JobApplication
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public required Position Position { get; set; }
    public ApplicationStatus Status { get; set; }
    public Recruiter? Recruter { get; set; }
    public DateTime? AppliedDate { get; set; }
}

public class Recruiter
{
    public string Name { get; set; } = string.Empty;
}

public enum ApplicationStatus
{
    NotApplied,
    InProgress,
    Rejected,
    Success
}