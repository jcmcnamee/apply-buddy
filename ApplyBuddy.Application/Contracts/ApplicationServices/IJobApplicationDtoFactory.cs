using ApplyBuddy.Application.DTOs.JobApplication;
using ApplyBuddy.Domain.Aggregates.JobApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Application.Contracts.ApplicationServices;
public interface IJobApplicationDtoFactory
{
    public abstract static JobApplicationDto MapToDto(JobApplication application);
}
