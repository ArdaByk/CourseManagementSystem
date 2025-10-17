namespace CMS.Application.Features.Courses.Queries.GetTeacherById;

public class GetCourseByIdResponse
{
    public Guid Id { get; set; }
    public string CourseName { get; set; }
    public string Description { get; set; }
    public int DurationWeeks { get; set; }
    public int WeeklyHours { get; set; }
    public char Status { get; set; }
}