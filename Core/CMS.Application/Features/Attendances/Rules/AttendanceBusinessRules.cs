using CMS.Application.Abstractions.Services;
using System;
using System.Threading.Tasks;

namespace CMS.Application.Features.Attendances.Rules
{
    public class AttendanceBusinessRules
    {
        private readonly IAttendanceService _attendanceService;
        public AttendanceBusinessRules(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        public async Task EnsureSingleAttendancePerDayAsync(Guid studentId, Guid courseGroupId, System.DateTime date)
        {
            var exists = await _attendanceService.AnyAsync(a => a.StudentId == studentId && a.CourseGroupId == courseGroupId && a.Date == date);
            if (exists) throw new Exception("Bu öğrenci için bu gün yoklama zaten alınmış.");
        }
        public async Task EnsureAttendanceExistsAsync(Guid attendanceId)
        {
            var exists = await _attendanceService.AnyAsync(a => a.Id == attendanceId);
            if (!exists) throw new Exception("Yoklama kaydı bulunamadı.");
        }
    }
}
