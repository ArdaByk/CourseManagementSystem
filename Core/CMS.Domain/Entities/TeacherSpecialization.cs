using CMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities;

public class TeacherSpecialization : BaseEntity<Guid>
{
    public TeacherSpecialization(Guid id, Guid teacherId, Guid specializationId)
        :base(id)
    {
        TeacherId = teacherId;
        SpecializationId = specializationId;
    }
    public TeacherSpecialization()
    {
        
    }

    public Guid TeacherId { get; set; }
    public Guid SpecializationId { get; set; }

    public virtual Teacher Teacher { get; set; }
    public virtual Specialization Specialization { get; set; }
}
