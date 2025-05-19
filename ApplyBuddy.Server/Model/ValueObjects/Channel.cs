using ApplyBuddy.Server.Enums;
using ApplyBuddy.Server.Model.Common;
using ApplyBuddy.Server.Model.Listings;

namespace ApplyBuddy.Server.Model.ValueObjects;

// public record Channel(Company Company, ApplicationChannelType Type) : ValueObject;

public record Channel
{
    public Guid? CompanyId { get; init; }
    public Guid? RecruiterId { get; init; }
    public ChannelType Type { get; init; }
    
    public bool IsIncoming() => Type is ChannelType.IncomingEmail or ChannelType.IncomingPhoneCall;
    
}