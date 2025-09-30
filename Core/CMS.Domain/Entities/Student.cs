using CMS.Domain.Common;

namespace CMS.Domain.Entities;

public class Student : BaseEntity<Guid>
{
    public Student(Guid id, string firstName, string lastName, string nationalId, char gender, DateTime birthDate, string phone, string email, string address, string emergencyContactName, string emergencyContactPhone, string emergencyContactRelation, char status, string photoPath)
        :base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        NationalId = nationalId;
        Gender = gender;
        BirthDate = birthDate;
        Phone = phone;
        Email = email;
        Address = address;
        EmergencyContactName = emergencyContactName;
        EmergencyContactPhone = emergencyContactPhone;
        EmergencyContactRelation = emergencyContactRelation;
        Status = status;
        PhotoPath = photoPath;

        Attendances = new List<Attendance>();
        StudentCourses = new List<StudentCourse>();
        ExamResults = new List<ExamResult>();
    }

    public Student()
    {
        Attendances = new List<Attendance>();
        StudentCourses = new List<StudentCourse>();
        ExamResults = new List<ExamResult>();
    }

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

    public virtual ICollection<Attendance> Attendances { get; set; }
    public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    public virtual ICollection<ExamResult> ExamResults { get; set; }
}