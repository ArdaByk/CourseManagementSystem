using CMS.Domain.Common;

namespace CMS.Domain.Entities;

public class Role : BaseEntity<Guid>
{
    public Role(Guid id, string roleName, string description)
       :base(id)
    {
        RoleName = roleName;
        Description = description;

        Users = new List<User>();
    }
    public Role()
    {
        Users = new List<User>();
    }

    public string RoleName { get; set; }
    public string Description { get; set; }

    public virtual ICollection<User> Users { get; set; }
}