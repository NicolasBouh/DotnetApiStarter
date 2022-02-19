namespace DotnetApiStarter.Domain.Core;

public abstract class AuditableEntity : BaseEntity
{
    public int CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }
    
    public int UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }
}