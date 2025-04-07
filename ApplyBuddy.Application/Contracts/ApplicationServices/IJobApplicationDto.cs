using ApplyBuddy.Application.DTOs.JobApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Application.Contracts.ApplicationServices;
public interface IJobApplicationDto<T> where T : JobApplicationDto
{

}
