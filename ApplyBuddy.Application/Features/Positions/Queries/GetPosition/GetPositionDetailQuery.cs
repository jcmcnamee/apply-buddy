﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Application.Features.Positions.Queries.GetPosition;
public class GetPositionDetailQuery : IRequest<GetPositionDetailVm>
{
    public Guid Id { get; set; }
}
