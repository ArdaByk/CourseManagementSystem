using CMS.Domain.Entities;

namespace CMS.Application.Features.Attendances.Queries.GetListAttendancesByCourseGroupId
{
    public class GetListAttendancesByCourseGroupIdResponse
    {
        public DateTime Key { get; set; }
        public ICollection<GetListAttendancesByCourseGroupIdGroupDto> Students { get; set; }
    }

    public class GetListAttendancesByCourseGroupIdGroupDto
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public string NationalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
    }
}