using CMS.Domain.Common;

namespace CMS.Domain.Entities;

public class CourseGroup : BaseEntity<Guid>
{
    public CourseGroup(Guid id, string groupName, int quota, DateTime startedDate, DateTime endedDate, Guid courseId, Guid classId, Guid teacherId)
        :base(id)
    {
        GroupName = groupName;
        Quota = quota;
        StartedDate = startedDate;
        EndedDate = endedDate;
        CourseId = courseId;
        ClassId = classId;
        TeacherId = teacherId;

        StudentCourses = new List<StudentCourse>();
        CourseSchedules = new List<CourseSchedule>();
        Attendances = new List<Attendance>();

    }

    public CourseGroup()
    {
        StudentCourses = new List<StudentCourse>();
        CourseSchedules = new List<CourseSchedule>();
        Attendances = new List<Attendance>();
    }

    public string GroupName { get; set; }
    public int Quota { get; set; }
    public DateTime StartedDate { get; set; }
    public DateTime EndedDate { get; set; }
    public Guid CourseId { get; set; }
    public Guid ClassId { get; set; }
    public Guid TeacherId { get; set; }

    public virtual Course Course { get; set; }
    public virtual Class Class { get; set; }
    public virtual Teacher Teacher { get; set; }
    public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    public virtual ICollection<CourseSchedule> CourseSchedules { get; set; }
    public virtual ICollection<Attendance> Attendances { get; set; }

}