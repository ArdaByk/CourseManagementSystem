using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Business;
using System;
using System.Threading.Tasks;

namespace CMS.Application.Features.Classes.Rules
{
    public class ClassBusinessRules : BusinessRule
    {
        private readonly IClassService _classService;
        public ClassBusinessRules(IClassService classService)
        {
            _classService = classService;
        }
        public async Task EnsureClassNameIsUniqueAsync(string className)
        {
            var exists = await _classService.AnyAsync(c => c.ClassName == className);
            if (exists) throw new Exception("Bu sınıf adı zaten mevcut.");
        }
        public async Task EnsureClassExistsAsync(Guid classId)
        {
            var exists = await _classService.AnyAsync(c => c.Id == classId);
            if (!exists) throw new Exception("Sınıf bulunamadı.");
        }
        public void EnsureCapacityInLimit(int? capacity)
        {
            if (capacity < 1 || capacity > 200) throw new Exception("Sınıf kapasitesi 1-200 arasında olmalıdır.");
        }
    }
}
