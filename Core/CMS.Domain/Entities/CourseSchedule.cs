using CMS.Domain.Common;

namespace CMS.Domain.Entities;

public class CourseSchedule : BaseEntity<Guid>
{
    public CourseSchedule(Guid id, int dayOfWeek, TimeSpan startTime, TimeSpan endTime, Guid courseGroupId)
        :base(id)
    {
        DayOfWeek = dayOfWeek;
        StartTime = startTime;
        EndTime = endTime;
        CourseGroupId = courseGroupId;
    }
    public CourseSchedule()
    {
        
    }

    public int DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public Guid CourseGroupId { get; set; }

    public virtual CourseGroup CourseGroup { get; set; }
}