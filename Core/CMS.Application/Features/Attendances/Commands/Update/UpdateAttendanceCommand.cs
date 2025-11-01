using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Authentication;
using CMS.Application.Common.Authorization;
using CMS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Attendances.Commands.Update;

[Authorize(RoleConstants.Admin, RoleConstants.Teacher, RoleConstants.Staff)]
public class UpdateAttendanceCommand : IRequest<UpdateAttendanceResponse>
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public Guid CourseGroupId { get; set; }
    public DateTime Date { get; set; }
    public bool Status { get; set; }

    public class UpdateAttendanceCommandHandler : IRequestHandler<UpdateAttendanceCommand, UpdateAttendanceResponse>
    {
        private readonly IAttendanceService attendanceService;
        private readonly ICourseGroupService courseGroupService;
        private readonly IMapper mapper;

        public UpdateAttendanceCommandHandler(IAttendanceService attendanceService, ICourseGroupService courseGroupService,IMapper mapper)
        {
            this.attendanceService = attendanceService;
            this.courseGroupService = courseGroupService;
            this.mapper = mapper;
        }

        public async Task<UpdateAttendanceResponse> Handle(UpdateAttendanceCommand request, CancellationToken cancellationToken)
        {
                var attendance = await attendanceService.GetAsync(
                    predicate: a => a.Id == request.Id,
                    include: a => a.Include(a => a.CourseGroup),
                    enableTracking: false,
                    cancellationToken: cancellationToken
                );

                if (attendance == null)
                {
                    throw new Exception("Yoklama kaydı bulunamadı.");
                }

                var courseGroup = await courseGroupService.GetAsync(
                    predicate: cg => cg.Id == attendance.CourseGroupId,
                    enableTracking: false,
                    cancellationToken: cancellationToken
                );

            Attendance attendanceToUpdate = await attendanceService.GetAsync(a => a.Id == request.Id, enableTracking: true, cancellationToken: cancellationToken);

            mapper.Map(request, attendanceToUpdate);

            Attendance result = await attendanceService.UpdateAsync(attendanceToUpdate);

            UpdateAttendanceResponse response = mapper.Map<UpdateAttendanceResponse>(result);

            return response;
        }
    }
}
