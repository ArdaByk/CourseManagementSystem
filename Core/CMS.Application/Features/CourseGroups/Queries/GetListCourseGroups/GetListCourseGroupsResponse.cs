using CMS.Domain.Entities;

namespace CMS.Application.Features.CourseGroups.Queries.GetListCourseGroups
{
    public class GetListCourseGroupsResponse
    {
        public Guid Id { get; set; }
        public string GroupName { get; set; }
        public int Quota { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime EndedDate { get; set; }
        public Course Course { get; set; }
    }
}