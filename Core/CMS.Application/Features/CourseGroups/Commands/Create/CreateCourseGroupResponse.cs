namespace CMS.Application.Features.CourseGroups.Commands.Create
{
    public class CreateCourseGroupResponse
    {
        public string GroupName { get; set; }
        public int Quota { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime EndedDate { get; set; }
    }
}