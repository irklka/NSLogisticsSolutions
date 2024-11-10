namespace NSLogistics.Core.Common;

public abstract class BaseEntity
{
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public Guid CreatedById { get; set; }
}
