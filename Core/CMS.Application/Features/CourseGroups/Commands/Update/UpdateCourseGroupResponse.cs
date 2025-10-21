namespace CMS.Application.Features.CourseGroups.Commands.Update
{
    public class UpdateCourseGroupResponse
    {
        public Guid Id { get; set; }
        public string GroupName { get; set; }
        public int Quota { get; set; }
    }
}