namespace CMS.Application.Features.Teachers.Queries.GetListTeachers;

public class GetListTeacherResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public char Status { get; set; }
}