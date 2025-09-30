namespace CMS.Domain.Common;

public interface IEntityTimestamp
{
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}