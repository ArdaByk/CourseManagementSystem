using CMS.Application.Abstractions.Services;
using System;
using System.Threading.Tasks;

namespace CMS.Application.Features.ExamResults.Rules
{
    public class ExamResultBusinessRules
    {
        private readonly IExamResultService _examResultService;
        public ExamResultBusinessRules(IExamResultService examResultService)
        {
            _examResultService = examResultService;
        }

        public async Task EnsureStudentHasNoExamResultForExamAsync(Guid studentId, Guid examId)
        {
            var exists = await _examResultService.AnyAsync(e => e.StudentId == studentId && e.ExamId == examId);
            if (exists) throw new Exception("Bu öğrenci için bu sınav sonucu zaten mevcut.");
        }
        public async Task EnsureExamResultExistsAsync(Guid examResultId)
        {
            var exists = await _examResultService.AnyAsync(e => e.Id == examResultId);
            if (!exists) throw new Exception("Sınav sonucu bulunamadı.");
        }
    }
}
