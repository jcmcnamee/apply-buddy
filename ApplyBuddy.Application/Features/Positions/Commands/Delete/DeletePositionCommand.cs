using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Application.Features.Positions.Commands.Delete;
public class DeletePositionCommand : IRequest
{
    public Guid Id { get; set; }
}
