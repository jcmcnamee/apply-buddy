using ApplyBuddy.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Application.Features.Positions.Queries.GetPosition;
internal class GetPositionDetailHandler : IRequestHandler<GetPositionDetailQuery, GetPositionDetailVm>
{
    private readonly IMapper _mapper;
    private readonly IPositionRepository _positionRepository;

    public GetPositionDetailHandler(IMapper mapper, IPositionRepository positionRepository)
    {
        _mapper = mapper;
        _positionRepository = positionRepository;
    }

    public async Task<GetPositionDetailVm> Handle(GetPositionDetailQuery request, CancellationToken cancellationToken)
    {
        var position = await _positionRepository.GetByIdAsync(request.Id);

        if (position == null)
        {
            // TODO: Implement Not Found Exception
        }

        var positionVm = _mapper.Map<GetPositionDetailVm>(position);

        return positionVm;
    }
}
