namespace ApplyBuddy.Server.Domain.Common;

public interface IAuditableEntity
{
    string? CreatedBy { get; set; }
    DateTime CreatedDate { get; set; }
    string? LastModifiedBy { get; set; }
    DateTime? LastModifiedDate { get; set; }
}

public class AuditableEntity : IAuditableEntity
{
    public string? CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}

public class AuditableEntity<TId> : BaseEntity<TId>, IAuditableEntity
{
    public string? CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}