using CMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities;

public class Specialization : BaseEntity<Guid>
{
    public Specialization(Guid id, string specializationName)
        :base(id)
    {
        SpecializationName = specializationName;
        TeacherSpecializations = new List<TeacherSpecialization>();
        Courses = new List<Course>();
    }
    public Specialization()
    {
        TeacherSpecializations = new List<TeacherSpecialization>();
        Courses = new List<Course>();
    }
    public string SpecializationName { get; set; }

    public ICollection<TeacherSpecialization> TeacherSpecializations { get; set; }
    public ICollection<Course> Courses { get; set; }


}
