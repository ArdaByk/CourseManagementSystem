namespace CMS.Application.Features.Attendances.Commands.Update
{
    public class UpdateAttendanceResponse
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public Guid CourseGroupId { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }

    }
}