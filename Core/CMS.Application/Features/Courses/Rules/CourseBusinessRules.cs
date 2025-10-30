using CMS.Application.Abstractions.Services;
using System;
using System.Threading.Tasks;

namespace CMS.Application.Features.Courses.Rules
{
    public class CourseBusinessRules
    {
        private readonly ICourseService _courseService;
        public CourseBusinessRules(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public async Task EnsureCourseNameIsUniqueAsync(string courseName)
        {
            var exists = await _courseService.AnyAsync(c => c.CourseName == courseName);
            if (exists) throw new Exception("Bu ders adı zaten sistemde mevcut.");
        }
        public async Task EnsureCourseExistsAsync(Guid courseId)
        {
            var exists = await _courseService.AnyAsync(c => c.Id == courseId);
            if (!exists) throw new Exception("Ders bulunamadı.");
        }
        public void EnsureWeeklyHoursInLimit(int hours)
        {
            if (hours < 1 || hours > 40)
                throw new Exception("Haftalık ders saati 1-40 arasında olmalıdır.");
        }
    }
}
