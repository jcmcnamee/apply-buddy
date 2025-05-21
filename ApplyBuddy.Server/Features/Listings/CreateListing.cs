using ApplyBuddy.Server.Domain.Listings;
using ApplyBuddy.Server.Domain.ValueObjects;
using ApplyBuddy.Server.Enums;
using ApplyBuddy.Server.Features.Recruiters;
using ApplyBuddy.Server.Infrastructure;
using FluentValidation;
using MediatR;

namespace ApplyBuddy.Server.Features.Listings;

public static class CreateListing
{
    public class CreateListingCommand : IRequest<Guid>
    {
        public required Position Position { get; init; }
        public Channel? DiscoverySource { get; init; }
        public ListingStatus Status { get; init; }
        public DateTime? ListedDate { get; init; }
        public DateTime? ClosingDate { get; init; }

        public CreateRecruiter.CreateRecruiterCommand? Recruiter { get; init; }
        public int? RecruiterId { get; init; }
    }

    public class Validator : AbstractValidator<CreateListingCommand>
    {
        public Validator()
        {
            RuleFor(x => x.Position).NotNull();
        }
    }

    internal sealed class Handler : IRequestHandler<CreateListingCommand, Guid>
    {
        private readonly ApplyBuddyDbContext _dbContext;
        private readonly IValidator<CreateListingCommand> _validator;

        public Handler(ApplyBuddyDbContext dbContext, IValidator<CreateListingCommand> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        public Task<Guid> Handle(CreateListingCommand request, CancellationToken cancellationToken)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }
    }
}