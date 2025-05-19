using ApplyBuddy.Server.Enums;
using MediatR;

namespace ApplyBuddy.Server.Features.JobApplications;

public static class CreateApplicationDetails
{
    public class Command : IRequest<int>
    {
        public ApplicationState State { get; init; }
        public Guid ApplicationId { get; init; }
        public DateTime? AppliedDate { get; init; }
        public CreateChannel.Command? Channel { get; init; }
        public int? ChannelId { get; init; }
    }
}