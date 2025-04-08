using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Application.Features.JobApplications.Commands.Delete;
public class DeleteJobApplicationCommand : IRequest
{
    public Guid Id { get; set; }
}
