using ApplyBuddy.Application.DTOs.JobApplication;
using ApplyBuddy.Domain.Aggregates.JobApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Application.Extensions;
public static class JobApplicationExtensions
{
    public static JobApplicationDto ToDto<T>(this JobApplication application, JobApplicationDtoType type) where T : JobApplication
    {
        switch (type)
        {
            case JobApplicationDtoType.Standard:
                {
                    return new JobApplicationDto
                    {
                        Id = application.Id,
                        Name = application.Name,
                        Recruiter = application.Recruiter != null ? application.Recruiter.Name : null,
                        Status = application.Status,
                        AppliedDate = application.AppliedDate,
                        ActiveTasks = application.Tasks.Where(t => t.IsActive).Count(),
                    };
                }
            case JobApplicationDtoType.Detail:
                {
                    return new JobApplicationWithTasksDto
                    {
                        Id = application.Id,
                        Name = application.Name,
                        Recruiter = application.Recruiter != null ? application.Recruiter.Name : null,
                        Status = application.Status,
                        AppliedDate = application.AppliedDate,
                        ActiveTasks = application.Tasks.Where(t => t.IsActive).Count(),
                        Tasks = application.Tasks
                    };
                }
            default:
                throw new ArgumentException("Invalid JobApplicationDto type");
        }

    }
}

public enum JobApplicationDtoType
{
    Standard,
    Detail,
    List,
}
