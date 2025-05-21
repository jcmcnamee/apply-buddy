using ApplyBuddy.Server.Enums;

namespace ApplyBuddy.Server.Domain.ValueObjects;

// public record Channel(Company Company, ApplicationChannelType Type) : ValueObject;

public record Channel
{
    public Guid? CompanyId { get; init; }
    public Guid? RecruiterId { get; init;}
    public ChannelType Type { get; init; }

    private Channel()
    {
    }
    public bool IsIncoming() => Type is ChannelType.IncomingEmail or ChannelType.IncomingPhoneCall;
    
}