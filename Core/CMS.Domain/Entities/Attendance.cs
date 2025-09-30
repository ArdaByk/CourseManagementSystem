using CMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities;

public class Attendance : BaseEntity<Guid>
{
    public Attendance(Guid id, Guid studentId, Guid courseId, Guid courseGroupId, DateTime date, bool status)
        :base(id)
    {
        StudentId = studentId;
        CourseId = courseId;
        CourseGroupId = courseGroupId;
        Date = date;
        Status = status;
    }

    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public Guid CourseGroupId { get; set; }
    public DateTime Date { get; set; }
    public bool Status { get; set; }

    public virtual Student Student { get; set; }
    public virtual Course Course { get; set; }
    public virtual CourseGroup CourseGroup { get; set; }
}
