using CMS.Domain.Entities;

namespace CMS.Application.Features.Teachers.Queries.GetTeacherById;

public class GetTeacherByIdResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string SalaryType { get; set; }
    public float SalaryAmount { get; set; }
    public DateTime HiredDate { get; set; }
    public char Status { get; set; }
    public ICollection<TeacherSpecialization> TeacherSpecializations { get; set; }
}