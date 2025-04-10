using ApplyBuddy.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Application.Features.Positions.Commands.Create;
public class CreatePositionResponse : BaseResponse
{
    public CreatePositionResponse() : base()
    {
        
    }

    public CreatePositionResponseDto Position { get; set; } = new();
}
