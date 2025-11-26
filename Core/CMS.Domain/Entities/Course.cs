using CMS.Domain.Common;

namespace CMS.Domain.Entities;

public class Course : BaseEntity<Guid>
{
    public Course(Guid id, string courseName, string description, int durationWeeks, int weeklyHours, char status, Guid specializationId)
       : base(id)
    {
        CourseName = courseName;
        Description = description;
        DurationWeeks = durationWeeks;
        WeeklyHours = weeklyHours;
        Status = status;

        CourseGroups = new List<CourseGroup>();
        Exams = new List<Exam>();
        StudentCourses = new List<StudentCourse>();
        Attendances = new List<Attendance>();
        SpecializationId = specializationId;
    }

    public Course()
    {
        CourseGroups = new List<CourseGroup>();
        Exams = new List<Exam>();
        StudentCourses = new List<StudentCourse>();
        Attendances = new List<Attendance>();
    }

    public string CourseName { get; set; }
    public string Description { get; set; }
    public int DurationWeeks { get; set; }
    public int WeeklyHours { get; set; }
    public char Status { get; set; }
    public Guid SpecializationId { get; set; }

    public virtual Specialization Specialization { get; set; }
    public virtual ICollection<CourseGroup> CourseGroups { get; set; }
    public virtual ICollection<Exam> Exams { get; set; }
    public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    public virtual ICollection<Attendance> Attendances { get; set; }
}