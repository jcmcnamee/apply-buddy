using ApplyBuddy.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Application.Features.JobApplications.Commands.Create;
public class CreateJobApplicationValidator : AbstractValidator<CreateJobApplicationCommand>
{
    private readonly IJobApplicationRepository _applicationRepository;

    public CreateJobApplicationValidator(IJobApplicationRepository applicationRepository)
    {
        RuleFor(a => a.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(a => a.Description)
            .MaximumLength(4000).WithMessage("{PropertyName} must not exceed 4000 characters.");

        RuleFor(a => a.AppliedDate)
            .GreaterThan(DateTime.Now).WithMessage("{PropertyName} cannot be in the future.");
        _applicationRepository = applicationRepository;
    }

    private async Task<bool> ApplicationNameAndDateUnique(CreateJobApplicationCommand application, CancellationToken cancellationToken)
    {

        if(!application.AppliedDate.HasValue)
        {
            return true;
        }

        return !(await _applicationRepository.IsJobApplicationNameAndDateUnique(application.Name, application.AppliedDate.Value));

    }
}
