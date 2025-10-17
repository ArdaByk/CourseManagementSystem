namespace CMS.Application.Features.Students.Queries.GetListStudents;

public class GetListStudentResponse
{
    public Guid Id { get; set; }
    public string NationalId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public char Status { get; set; }
}