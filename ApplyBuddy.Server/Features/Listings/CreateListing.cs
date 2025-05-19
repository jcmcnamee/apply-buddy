using ApplyBuddy.Server.Enums;
using ApplyBuddy.Server.Features.Recruiters;
using ApplyBuddy.Server.Infrastructure;
using ApplyBuddy.Server.Model.Listings;
using ApplyBuddy.Server.Model.ValueObjects;
using FluentValidation;
using MediatR;

namespace ApplyBuddy.Server.Features.Listings;

public static class CreateListing
{
    public class Command : IRequest<Guid>
    {
        public required Position Position { get; init; }
        public Channel? DiscoverySource { get; init; }
        public ListingStatus Status { get; init; }
        public DateTime? ListedDate { get; init; }
        public DateTime? ClosingDate { get; init; }

        public CreateRecruiter.Command? Recruiter { get; init; }
        public int? RecruiterId { get; init; }
    }

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(x => x.Position).NotNull();
        }
    }

    internal sealed class Handler : IRequestHandler<Command, Guid>
    {
        private readonly ApplyBuddyDbContext _dbContext;
        private readonly IValidator<Command> _validator;

        public Handler(ApplyBuddyDbContext dbContext, IValidator<Command> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        public Task<Guid> Handle(Command request, CancellationToken cancellationToken)
        {
            
        }
    }
}