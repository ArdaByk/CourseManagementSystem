using CMS.Application.Abstractions.Services;
using System;
using System.Threading.Tasks;

namespace CMS.Application.Features.StudentCourses.Rules
{
    public class StudentCourseBusinessRules
    {
        private readonly IStudentCourseService _studentCourseService;
        public StudentCourseBusinessRules(IStudentCourseService studentCourseService)
        {
            _studentCourseService = studentCourseService;
        }

        public async Task EnsureStudentNotExistsInCourseGroupAsync(Guid studentId, Guid courseGroupId)
        {
            var exists = await _studentCourseService.AnyAsync(sc => sc.StudentId == studentId && sc.CourseGroupId == courseGroupId);
            if (exists) throw new Exception("Bu öğrenci bu kurs grubuna kayıtlı.");
        }
        public async Task EnsureStudentCourseExistsAsync(Guid studentCourseId)
        {
            var exists = await _studentCourseService.AnyAsync(sc => sc.Id == studentCourseId);
            if (!exists) throw new Exception("Kayıt bulunamadı.");
        }
    }
}
