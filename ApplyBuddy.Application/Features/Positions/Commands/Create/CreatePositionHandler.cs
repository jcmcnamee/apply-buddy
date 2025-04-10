using ApplyBuddy.Application.Contracts.Persistence;
using ApplyBuddy.Domain.Aggregates.Position;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Application.Features.Positions.Commands.Create;
public class CreatePositionHandler : IRequestHandler<CreatePositionCommand, CreatePositionResponse>
{
    private readonly IMapper _mapper;
    private readonly IPositionRepository _positionRepository;

    public CreatePositionHandler(IMapper mapper, IPositionRepository positionRepository)
    {
        _mapper = mapper;
        _positionRepository = positionRepository;
    }

    public async Task<CreatePositionResponse> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
    {
        var response = new CreatePositionResponse();
        var validator = new CreatePositionValidator(_positionRepository);

        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
        {
            response.Success = false;
            response.ValidationErrors = new List<string>();

            foreach (var error in validationResult.Errors)
            {
                response.ValidationErrors.Add(error.ErrorMessage);
            }
        }

        if (response.Success)
        {
            var position = _mapper.Map<Position>(request);
            position = await _positionRepository.AddAsync(position);
            response.Position = _mapper.Map<CreatePositionResponseDto>(position);
        }

        return response;

    }
}
