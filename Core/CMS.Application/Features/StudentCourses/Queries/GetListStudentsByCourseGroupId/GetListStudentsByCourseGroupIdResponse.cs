namespace CMS.Application.Features.StudentCourses.Queries.GetListStudentsByCourseGroupId
{
    public class GetListStudentsByCourseGroupIdResponse
    {
        public Guid Id { get; set; }
        public string NationalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
    }
}