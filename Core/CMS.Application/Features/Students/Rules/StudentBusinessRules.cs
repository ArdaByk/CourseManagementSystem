using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Business;
using System;
using System.Threading.Tasks;

namespace CMS.Application.Features.Students.Rules
{
    public class StudentBusinessRules : BusinessRule
    {
        private readonly IStudentService _studentService;
        public StudentBusinessRules(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task EnsureNationalIdIsUniqueAsync(string nationalId)
        {
            var exists = await _studentService.AnyAsync(s => s.NationalId == nationalId);
            if (exists) throw new Exception("Bu TC Kimlik numarasıyla kayıtlı öğrenci mevcut.");
        }
        public async Task EnsureEmailIsUniqueAsync(string email)
        {
            var exists = await _studentService.AnyAsync(s => s.Email == email);
            if (exists) throw new Exception("Bu email ile kayıtlı öğrenci mevcut.");
        }
        public async Task EnsureStudentExistsAsync(Guid studentId)
        {
            var exists = await _studentService.AnyAsync(s => s.Id == studentId);
            if (!exists) throw new Exception("Öğrenci bulunamadı.");
        }
    }
}
