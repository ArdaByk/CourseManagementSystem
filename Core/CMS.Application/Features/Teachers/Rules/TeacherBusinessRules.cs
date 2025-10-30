using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Application.Features.Teachers.Rules
{
    public class TeacherBusinessRules : BusinessRule
    {
        private readonly ITeacherService _teacherService;
        private readonly ISpecializationService _specializationService;

        public TeacherBusinessRules(ITeacherService teacherService, ISpecializationService specializationService)
        {
            _teacherService = teacherService;
            _specializationService = specializationService;
        }

        public async Task EnsureEmailIsUniqueAsync(string email)
        {
            var exists = await _teacherService.AnyAsync(t => t.Email == email);
            if (exists) throw new Exception("Bu e-posta ile kayıtlı öğretmen zaten mevcut.");
        }

        public async Task EnsurePhoneIsUniqueAsync(string phone)
        {
            var exists = await _teacherService.AnyAsync(t => t.Phone == phone);
            if (exists) throw new Exception("Bu telefon ile kayıtlı öğretmen zaten mevcut.");
        }

        public async Task EnsureTeacherExistsAsync(Guid teacherId)
        {
            var exists = await _teacherService.AnyAsync(t => t.Id == teacherId);
            if (!exists) throw new Exception("Bu Id'ye sahip öğretmen bulunamadı.");
        }

        public async Task EnsureSpecializationsExistAsync(IEnumerable<Guid> specializationIds)
        {
            foreach (var id in specializationIds)
            {
                var specialization = await _specializationService.GetAsync(s => s.Id == id);
                if (specialization == null)
                    throw new Exception($"Id {id} olan uzmanlık alanı bulunamadı.");
            }
        }
    }
}
