using ApplyBuddy.Domain.Aggregates.JobApplication;
using ApplyBuddy.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Application.DTOs.JobApplications;
public class JobApplicationWithTasksDto : JobApplicationDto
{
    public List<Domain.Aggregates.JobApplication.UserTask> Tasks { get; set; } = new List<Domain.Aggregates.JobApplication.UserTask>();
}
