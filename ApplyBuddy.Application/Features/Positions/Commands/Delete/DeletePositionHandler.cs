using ApplyBuddy.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace ApplyBuddy.Application.Features.Positions.Commands.Delete;
public class DeletePositionHandler : IRequestHandler<DeletePositionCommand>
{
    private readonly IMapper _mapper;
    private readonly IPositionRepository _positionRepository;

    public DeletePositionHandler(IMapper mapper, IPositionRepository positionRepository)
    {
        _mapper = mapper;
        _positionRepository = positionRepository;
    }

    public async Task Handle(DeletePositionCommand request, CancellationToken cancellationToken)
    {
        var positionToDelete = await _positionRepository.GetByIdAsync(request.Id);
        if (positionToDelete == null)
        {
            // TODO: Implement NOt Found Exception
        }

        await _positionRepository.DeleteAsync(positionToDelete);
    }
}

