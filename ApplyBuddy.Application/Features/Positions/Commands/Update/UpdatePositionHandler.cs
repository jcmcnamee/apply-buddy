using ApplyBuddy.Application.Contracts.Persistence;
using ApplyBuddy.Domain.Aggregates.Position;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Application.Features.Positions.Commands.Update;
public class UpdatePositionHandler : IRequestHandler<UpdatePositionCommand>
{
    private readonly IMapper _mapper;
    private readonly IPositionRepository _positionRepository;

    public UpdatePositionHandler(IMapper mapper, IPositionRepository positionRepository)
    {
        _mapper = mapper;
        _positionRepository = positionRepository;
    }

    public async Task Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
    {
        var positionToUpdate = await _positionRepository.GetByIdAsync(request.Id);

        if (positionToUpdate == null)
        {
            // TODO: Implement Not Found Exception
        }

        _mapper.Map(request, positionToUpdate, typeof(UpdatePositionCommand), typeof(Position));

        await _positionRepository.UpdateAsync(positionToUpdate);
    }
}
