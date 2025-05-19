using ApplyBuddy.Server.Enums;

namespace ApplyBuddy.Server.Extensions;
public static class ListingDiscoverySourceExtensions
{
    public static string ToFriendlyString(this ListingDiscoverySource discoverySource)
    {
        return discoverySource switch
        {
            ListingDiscoverySource.CompanyWebsite => "Company website",
            ListingDiscoverySource.JobBoard => "Job board",
            ListingDiscoverySource.SocialMedia => "Social media",
            ListingDiscoverySource.RecruitmentAgency => "Recruitment agency",
            ListingDiscoverySource.Referral => "Referral",
            _ => throw new ArgumentOutOfRangeException(
                nameof(discoverySource),
                discoverySource,
                "Unhandled ListingDiscoverySource value")
        };
    }
}