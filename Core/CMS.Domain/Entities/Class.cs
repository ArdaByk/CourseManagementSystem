using CMS.Domain.Common;

namespace CMS.Domain.Entities;

public class Class : BaseEntity<Guid>
{
    public Class(Guid id, string className, int capacity, string location)
        :base(id)
    {
        ClassName = className;
        Capacity = capacity;
        Location = location;

        CourseGroups = new List<CourseGroup>();

    }

    public Class()
    {
        CourseGroups = new List<CourseGroup>();
    }

    public string ClassName { get; set; }
    public int Capacity { get; set; }
    public string Location { get; set; }

    public virtual ICollection<CourseGroup> CourseGroups { get; set; }
}