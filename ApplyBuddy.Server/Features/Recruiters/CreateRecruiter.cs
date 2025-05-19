using ApplyBuddy.Server.Enums;
using ApplyBuddy.Server.Model.Listings;
using ApplyBuddy.Server.Model.ValueObjects;
using FluentValidation;
using MediatR;

namespace ApplyBuddy.Server.Features.Recruiters;

public static class CreateRecruiter
{
    public record Command : IRequest
    {
        public PersonDetails? Details { get; init; }
        public RecruiterType Type { get; init; }
        public string? LinkedInProfile { get; init; }
        public List<Listing> Listings { get; init; } = new();
        public Company? Company { get; init; }
        public int? CompanyId { get; init; }
    }

    public class Validator : AbstractValidator<Recruiter>
    {
        
    }
}
