using CMS.Domain.Entities;

namespace CMS.Application.Features.CourseGroups.Queries.GetCourseGroupById
{
    public class GetCourseGroupByIdResponse
    {
        public Guid Id { get; set; }
        public string GroupName { get; set; }
        public int Quota { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime EndedDate { get; set; }

        public Course Course { get; set; }
        public Class Class { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<CourseSchedule> CourseSchedules { get; set; }
    }
}