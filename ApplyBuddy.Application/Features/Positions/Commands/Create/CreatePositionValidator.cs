using ApplyBuddy.Application.Contracts.Persistence;
using FluentValidation;

namespace ApplyBuddy.Application.Features.Positions.Commands.Create;
public class CreatePositionValidator : AbstractValidator<CreatePositionCommand>
{
    private readonly IPositionRepository _positionRepository;

    public CreatePositionValidator(IPositionRepository positionRepository)
    {
        _positionRepository = positionRepository;

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(p => p.ListedDate)
            .GreaterThan(DateTime.Now).WithMessage("{PropertyName} cannot be in the future.");

    }
}
