namespace CMS.Application.Features.Courses.Queries.GetListTeachers;

public class GetListCoursesResponse
{
    public Guid Id { get; set; }
    public string CourseName { get; set; }
    public string Description { get; set; }
    public char Status { get; set; }
}