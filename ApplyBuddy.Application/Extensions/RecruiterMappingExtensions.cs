using ApplyBuddy.Application.Features.DTOs;
using ApplyBuddy.Domain.Aggregates.Listing;
using ApplyBuddy.Domain.Extensions;

namespace ApplyBuddy.Application.Extensions;

public static class RecruiterMappingExtensions
{
    public static RecruiterVm ToViewModel(this Recruiter recruiter)
    {
        return new()
        {
            Name = recruiter.Details.FullName,
            Email = recruiter.Details.Email,
            Phone = recruiter.Details.PhoneNumber,
            LinkedIn = recruiter.LinkedInProfile,
            Type = recruiter.Type.ToFriendlyString(),
            Company = recruiter.Company?.Name,
        };
    }
}