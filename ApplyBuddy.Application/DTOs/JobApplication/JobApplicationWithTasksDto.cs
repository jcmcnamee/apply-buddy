using ApplyBuddy.Domain.Aggregates.JobApplication;
using ApplyBuddy.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Application.DTOs.JobApplication;
public class JobApplicationWithTasksDto : JobApplicationDto
{
    public List<ApplicationTask> Tasks { get; set; } = new List<ApplicationTask>();
}
