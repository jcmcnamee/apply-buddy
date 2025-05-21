using ApplyBuddy.Server.Domain.Companies;
using ApplyBuddy.Server.Domain.Listings;
using ApplyBuddy.Server.Domain.Recruiters;
using ApplyBuddy.Server.Domain.ValueObjects;
using ApplyBuddy.Server.Enums;
using FluentValidation;
using MediatR;

namespace ApplyBuddy.Server.Features.Recruiters;

public static class CreateRecruiter
{
    public record CreateRecruiterCommand : IRequest
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
