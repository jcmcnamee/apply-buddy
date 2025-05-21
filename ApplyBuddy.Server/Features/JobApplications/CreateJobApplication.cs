using ApplyBuddy.Server.Features.JobApplications.Extensions;
using ApplyBuddy.Server.Features.Listings;
using ApplyBuddy.Server.Infrastructure;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApplyBuddy.Server.Features.JobApplications;

[ApiController]
[Route("api/applications")]
public class CreateApplicationController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody]CreateJobApplication.CreateJobApplicationCommand createApplicationCreateJobApplicationCommand, CancellationToken cancellationToken)
    {
        var applicationId = await mediator.Send(createApplicationCreateJobApplicationCommand, cancellationToken);
        return Ok(applicationId);
    }
}

public static class CreateJobApplication
{
    public record CreateJobApplicationCommand : IRequest<Guid>
    {
        public string Name { get; init; } = string.Empty;
        public string Notes { get; init; } = string.Empty;
        public CreateListing.CreateListingCommand? Listing { get; init; }
        public Guid? ListingId { get; init; }
    }

    public class Validator : AbstractValidator<CreateJobApplicationCommand>
    {
        public Validator()
        {
            RuleFor(ja => ja)
                .Must(ja => (ja.ListingId != null) ^ (ja.Listing != null))
                .WithMessage("Reference to Listing entity invalid. Please provide either ListingId or new Listing entity.");

            RuleFor(ja => ja.Listing!)
                .SetValidator(new CreateListing.Validator())
                .When(ja => ja.Listing != null);

        }
    }

    internal sealed class Handler : IRequestHandler<CreateJobApplicationCommand, Guid>
    {
        private readonly ApplyBuddyDbContext _dbContext;
        private readonly IValidator<CreateJobApplicationCommand> _validator;

        public Handler(ApplyBuddyDbContext dbContext, IValidator<CreateJobApplicationCommand> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        public async Task<Guid> Handle(CreateJobApplicationCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            var application = request.ToDomainModel();

            if (request.Listing is not null)
            {
                // listing = request.Listing.ToDomainModel();
                // application.SetListing(listing);
            }
            
            await _dbContext.Applications.AddAsync(application, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return application.Id;
        }
    }
}
