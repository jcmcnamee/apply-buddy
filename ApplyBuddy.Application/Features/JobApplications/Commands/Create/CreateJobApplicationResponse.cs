using ApplyBuddy.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Application.Features.JobApplications.Commands.Create;
public class CreateJobApplicationResponse : BaseResponse
{
    public CreateJobApplicationResponse() : base()
    {
        
    }

    public CreateJobApplicationResponseDto JobApplication { get; set; } = new();
}
