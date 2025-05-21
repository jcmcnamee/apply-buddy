using ApplyBuddy.Server.Domain.Documents;

namespace ApplyBuddy.Server.Features.Common.Contracts;

public interface IChatService
{
    Task<CV?> TryParseCv(string cvAsString, DocumentType documentType);
}