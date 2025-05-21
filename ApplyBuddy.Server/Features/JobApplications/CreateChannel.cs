using ApplyBuddy.Server.Enums;
using MediatR;

namespace ApplyBuddy.Server.Features.JobApplications;

public static class CreateChannel
{
    public class CreateChannelCommand : IRequest<int>
    {
        string Name { get; init; } = string.Empty;

    }
}