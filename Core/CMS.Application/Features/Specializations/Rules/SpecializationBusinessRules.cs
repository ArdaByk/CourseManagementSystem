using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Business;
using System;
using System.Threading.Tasks;

namespace CMS.Application.Features.Specializations.Rules
{
    public class SpecializationBusinessRules : BusinessRule
    {
        private readonly ISpecializationService _specializationService;
        public SpecializationBusinessRules(ISpecializationService specializationService)
        {
            _specializationService = specializationService;
        }

        public async Task EnsureSpecializationNameIsUniqueAsync(string name)
        {
            var exists = await _specializationService.AnyAsync(s => s.SpecializationName == name);
            if (exists) throw new Exception("Bu uzmanlık adı zaten mevcut.");
        }

        public async Task EnsureSpecializationExistsAsync(Guid id)
        {
            var exists = await _specializationService.AnyAsync(s => s.Id == id);
            if (!exists) throw new Exception("Uzmanlık bulunamadı.");
        }
    }
}
