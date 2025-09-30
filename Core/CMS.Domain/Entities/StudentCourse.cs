using CMS.Domain.Common;

namespace CMS.Domain.Entities;

public class StudentCourse : BaseEntity<Guid>
{
    public StudentCourse(Guid id, DateTime registeredDate, DateTime completionDate, Guid studentId, Guid courseId, Guid courseGroupId)
        :base(id)
    {
        RegisteredDate = registeredDate;
        CompletionDate = completionDate;
        StudentId = studentId;
        CourseId = courseId;
        CourseGroupId = courseGroupId;
    }
    public StudentCourse()
    {
        
    }
    public DateTime RegisteredDate { get; set; }
    public DateTime CompletionDate { get; set; }
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public Guid CourseGroupId { get; set; }

    public virtual Student Student { get; set; }
    public virtual Course Course { get; set; }
    public virtual CourseGroup CourseGroup { get; set; }
}