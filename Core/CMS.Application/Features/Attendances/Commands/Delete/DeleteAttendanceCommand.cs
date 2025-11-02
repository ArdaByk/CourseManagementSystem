using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Authorization;
using CMS.Application.Features.StudentCourses.Commands.Delete;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Attendances.Commands.Delete;

[Authorize(RoleConstants.Admin, RoleConstants.Teacher, RoleConstants.Staff)]
public class DeleteAttendanceCommand : IRequest<DeleteAttendanceResponse>
{
    public Guid Id { get; set; }

    public class DeleteAttendanceCommandHandler : IRequestHandler<DeleteAttendanceCommand, DeleteAttendanceResponse>
    {
        private readonly IAttendanceService attendanceService;
        private readonly IMapper mapper;
        public DeleteAttendanceCommandHandler(IAttendanceService attendanceService, IMapper mapper)
        {
            this.attendanceService = attendanceService;
            this.mapper = mapper;
        }

        public async Task<DeleteAttendanceResponse> Handle(DeleteAttendanceCommand request, CancellationToken cancellationToken)
        {
            Attendance attendance = await attendanceService.GetAsync(a => a.Id == request.Id, cancellationToken: cancellationToken);

            Attendance result = await attendanceService.DeleteAsync(attendance);

            DeleteAttendanceResponse response = mapper.Map<DeleteAttendanceResponse>(result);

            return response;
        }
    }
}
