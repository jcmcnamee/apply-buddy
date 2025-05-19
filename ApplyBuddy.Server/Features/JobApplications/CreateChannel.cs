using ApplyBuddy.Server.Enums;
using MediatR;

namespace ApplyBuddy.Server.Features.JobApplications;

public static class CreateChannel
{
    public class Command : IRequest<int>
    {
        string Name { get; init; } = string.Empty;
        ApplicationChannelType Type { get; init; }
    }
}