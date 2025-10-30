using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Business;
using System;
using System.Threading.Tasks;

namespace CMS.Application.Features.Exams.Rules
{
    public class ExamBusinessRules : BusinessRule
    {
        private readonly IExamService _examService;
        private readonly ICourseService _courseService;

        public ExamBusinessRules(IExamService examService, ICourseService courseService)
        {
            _examService = examService;
            _courseService = courseService;
        }

        public async Task EnsureCourseExistsAsync(Guid courseId)
        {
            var exists = await _courseService.AnyAsync(c => c.Id == courseId);
            if (!exists) throw new Exception("Ders bulunamadı.");
        }

        public async Task EnsureExamExistsAsync(Guid examId)
        {
            var exists = await _examService.AnyAsync(e => e.Id == examId);
            if (!exists) throw new Exception("Sınav bulunamadı.");
        }

        public async Task EnsureNoDuplicateExamAsync(string examName, Guid courseId, DateTime examDate, Guid? excludeId = null)
        {
            var exists = await _examService.AnyAsync(e =>
                e.CourseId == courseId &&
                e.ExamName == examName &&
                e.ExamDate == examDate &&
                (excludeId == null || e.Id != excludeId.Value));
            if (exists) throw new Exception("Aynı tarih ve ad ile bu ders için sınav zaten kayıtlı.");
        }

        public void EnsureExamDateNotPast(DateTime examDate)
        {
            if (examDate.Date < DateTime.Now.Date)
                throw new Exception("Sınav tarihi geçmiş olamaz.");
        }
    }
}
