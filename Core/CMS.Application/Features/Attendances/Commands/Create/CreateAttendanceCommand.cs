using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Authorization;
using CMS.Application.Features.Attendances.Rules;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Application.Common.Authentication;

namespace CMS.Application.Features.Attendances.Commands.Create;

[Authorize(RoleConstants.Admin, RoleConstants.Teacher, RoleConstants.Staff)]
public class CreateAttendanceCommand : IRequest<CreateAttendanceResponse>
{
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public Guid CourseGroupId { get; set; }
    public DateTime Date { get; set; }
    public bool Status { get; set; }

    public class CreateAttendanceCommandHandler : IRequestHandler<CreateAttendanceCommand, CreateAttendanceResponse>
    {
        private readonly IAttendanceService attendanceService;
        private readonly ICourseGroupService courseGroupService;
        private readonly ITeacherService teacherService;
        private readonly IMapper mapper;
        private readonly AttendanceBusinessRules _attendanceBusinessRules;

        public CreateAttendanceCommandHandler(IAttendanceService attendanceService, ICourseGroupService courseGroupService, ITeacherService teacherService, IMapper mapper, AttendanceBusinessRules attendanceBusinessRules)
        {
            this.attendanceService = attendanceService;
            this.courseGroupService = courseGroupService;
            this.teacherService = teacherService;
            this.mapper = mapper;
            _attendanceBusinessRules = attendanceBusinessRules;
        }

        public async Task<CreateAttendanceResponse> Handle(CreateAttendanceCommand request, CancellationToken cancellationToken)
        {
            var currentUser = CurrentUserContext.Instance;

            if (currentUser.RoleName == RoleConstants.Teacher)
            {
                var courseGroup = await courseGroupService.GetAsync(
                    predicate: cg => cg.Id == request.CourseGroupId,
                    enableTracking: false,
                    cancellationToken: cancellationToken
                );

                if (courseGroup == null)
                {
                    throw new Exception("Kurs grubu bulunamadı.");
                }

                var teacherId = await AuthorizationHelper.GetTeacherIdFromCurrentUserAsync(teacherService);
                if (!teacherId.HasValue || courseGroup.TeacherId != teacherId.Value)
                {
                    throw new UnauthorizedAccessException("Bu kurs grubuna yoklama alma yetkiniz bulunmamaktadır.");
                }
            }

            await _attendanceBusinessRules.EnsureSingleAttendancePerDayAsync(request.StudentId, request.CourseGroupId, request.Date);
            Attendance attendance = mapper.Map<Attendance>(request);
            attendance = await attendanceService.AddAsync(attendance);
            return mapper.Map<CreateAttendanceResponse>(attendance);
        }
    }
}
