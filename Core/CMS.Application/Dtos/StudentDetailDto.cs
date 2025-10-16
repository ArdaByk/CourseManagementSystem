namespace CMS.Application.Dtos;

public class StudentDetailDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalId { get; set; }
    public char Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string EmergencyContactName { get; set; }
    public string EmergencyContactPhone { get; set; }
    public string EmergencyContactRelation { get; set; }
    public char Status { get; set; }
    public string PhotoPath { get; set; }
}
