using CMS.Domain.Common;

namespace CMS.Domain.Entities;

public class Teacher : BaseEntity<Guid>
{
    public Teacher(Guid id, string firstName, string lastName, string phone, string email, string specialization, string salaryType, float salaryAmount, DateTime hiredDate, char status)
        :base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Email = email;
        Specialization = specialization;
        SalaryType = salaryType;
        SalaryAmount = salaryAmount;
        HiredDate = hiredDate;
        Status = status;

        CourseGroups = new List<CourseGroup>();
    }
    public Teacher()
    {
        CourseGroups = new List<CourseGroup>();
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Specialization { get; set; }
    public string SalaryType { get; set; }
    public float SalaryAmount { get; set; }
    public DateTime HiredDate { get; set; }
    public char Status { get; set; }

    public virtual ICollection<CourseGroup> CourseGroups { get; set; }

}