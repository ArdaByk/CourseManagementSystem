namespace CMS.Application.Features.Courses.Commands.Update;

public class UpdateCourseResponse
{
    public string CourseName { get; set; }
    public string Description { get; set; }
    public int DurationWeeks { get; set; }
    public int WeeklyHours { get; set; }
    public char Status { get; set; }
}