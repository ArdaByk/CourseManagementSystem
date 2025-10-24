namespace CMS.Application.Features.Attendances.Commands.Create
{
    public class CreateAttendanceResponse
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public Guid CourseGroupId { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}