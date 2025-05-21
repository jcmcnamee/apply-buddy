using ApplyBuddy.Server.Domain.Common;

namespace ApplyBuddy.Server.Domain.Documents;

// TODO: Tighten up access on this class
public class DocumentRecord : AuditableEntity<Guid>
{
    public string FileName { get; set; } = string.Empty;
    public long FileSize { get; set; }
    public string FilePath { get; set; } = string.Empty;
    public DocumentType Type { get; set; }
}