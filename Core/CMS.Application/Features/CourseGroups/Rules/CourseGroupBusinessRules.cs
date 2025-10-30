using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Business;
using System;
using System.Threading.Tasks;

namespace CMS.Application.Features.CourseGroups.Rules
{
    public class CourseGroupBusinessRules : BusinessRule
    {
        private readonly ICourseGroupService _courseGroupService;
        private readonly ICourseService _courseService;
        private readonly IClassService _classService;
        private readonly ITeacherService _teacherService;

        public CourseGroupBusinessRules(
            ICourseGroupService courseGroupService,
            ICourseService courseService,
            IClassService classService,
            ITeacherService teacherService)
        {
            _courseGroupService = courseGroupService;
            _courseService = courseService;
            _classService = classService;
            _teacherService = teacherService;
        }

        public async Task EnsureGroupNameIsUniqueInCourseAsync(string groupName, Guid courseId)
        {
            var exists = await _courseGroupService.AnyAsync(x => x.GroupName == groupName && x.CourseId == courseId);
            if (exists) throw new Exception("Bu kurs için bu grup adı zaten kullanılıyor.");
        }
        public async Task EnsureCourseExistsAsync(Guid courseId)
        {
            var exists = await _courseService.AnyAsync(c => c.Id == courseId);
            if (!exists) throw new Exception("Ders bulunamadı.");
        }
        public async Task EnsureClassExistsAsync(Guid classId)
        {
            var exists = await _classService.AnyAsync(c => c.Id == classId);
            if (!exists) throw new Exception("Sınıf bulunamadı.");
        }
        public async Task EnsureTeacherExistsAsync(Guid teacherId)
        {
            var exists = await _teacherService.AnyAsync(t => t.Id == teacherId);
            if (!exists) throw new Exception("Eğitmen bulunamadı.");
        }
        public void EnsureStartDateIsBeforeEndDate(DateTime start, DateTime end)
        {
            if (end <= start) throw new Exception("Bitiş tarihi, başlangıç tarihinden sonra olmalı.");
        }
        public void EnsureQuotaInLimits(int quota)
        {
            if (quota < 1 || quota > 100) throw new Exception("Kota 1-100 arasında olmalıdır.");
        }
    }
}
