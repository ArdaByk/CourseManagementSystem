using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Common;

public class BaseEntity<TId> : IEntityTimestamp
{
    public TId Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }

    public BaseEntity()
    {
        Id = default(TId);
    }
    public BaseEntity(TId id)
    {
        Id=id;
    }
}
