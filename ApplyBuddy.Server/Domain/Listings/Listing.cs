using ApplyBuddy.Server.Contracts;
using ApplyBuddy.Server.Domain.Common;
using ApplyBuddy.Server.Domain.Recruiters;
using ApplyBuddy.Server.Domain.ValueObjects;
using ApplyBuddy.Server.Enums;

namespace ApplyBuddy.Server.Domain.Listings;

public class Listing : AuditableEntity<Guid>, IAggregateRoot
{
    public ListingStatus Status { get; private set; }
    public DateTime? ListedDate { get; private set; }
    public DateTime? ClosingDate {  get; private set; }
    public Channel? DiscoverySource { get; private set; }
    public int PositionId { get; private set; }
    public required Position Position { get; init; }
    
    
    public int? RecruiterId { get; private set; }
    public Recruiter? Recruiter { get; private set; }

    private Listing() { }
    
    public static Listing Create(Position position)
    {
        return new Listing
        {
            Id = Guid.NewGuid(),
            Position = position,
            Status = ListingStatus.Active,
        };
    }
    
    #region Smart constructors
    public static Listing Create(
        Position position,
        ListingStatus status,
        Recruiter? recruiter = null,
        Channel? discoverySource = null,
        DateTime? listedDate = null,
        DateTime? closingDate = null
        )
    {
        return new Listing
        {   Id = Guid.NewGuid(),
            Position = position,
            Status = status,
            DiscoverySource = discoverySource,
            Recruiter = recruiter,
            ListedDate = listedDate,
            ClosingDate = closingDate,
        };
    }

    public static Listing CreateForSeeding(
        Position position,
        ListingStatus status,
        Recruiter? recruiter = null,
        Channel? discoverySource = null,
        DateTime? listedDate = null,
        DateTime? closingDate = null,
        Guid? id = null
    )
    {
        return new Listing
        {
            Id = id ?? Guid.NewGuid(),
            Position = position,
            Status = status,
            DiscoverySource = discoverySource,
            Recruiter = recruiter,
            ListedDate = listedDate,
            ClosingDate = closingDate,
        };
    }
    
    #endregion
    
    public void SetDiscoverySource(Channel discoverySource)
    {
        DiscoverySource = discoverySource;
    }
    
    public void SetRecruiter(Recruiter recruiter)
    {
        Recruiter = recruiter;
    }

    public void Close()
    {
        Status = ListingStatus.Closed;
    }
    
    public void SetListedDate(DateTime listedDate)
    {
        if (listedDate > DateTime.UtcNow)
            throw new ArgumentException("Listed date cannot be in the future.", nameof(listedDate));
        
        if (ClosingDate is not null && listedDate > ClosingDate)
            throw new ArgumentException("Listed date cannot be after closing date.", nameof(listedDate));
        
        ListedDate = listedDate;
    }
    
    public void SetClosingDate(DateTime closingDate)
    {
        if (ListedDate is not null && closingDate < ListedDate)
            throw new ArgumentException("Closing date cannot be before listed date.", nameof(closingDate));
        
        ClosingDate = closingDate;
    }

    public void AssignExistingRecruiter(int recruiterId)
    {
        if (Recruiter is not null)
            throw new InvalidOperationException("");
        RecruiterId = recruiterId;
    }
}
