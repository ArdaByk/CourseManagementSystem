using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Features.Attendances.Rules;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Attendances.Commands.Create;

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
        private readonly IMapper mapper;
        private readonly AttendanceBusinessRules _attendanceBusinessRules;

        public CreateAttendanceCommandHandler(IAttendanceService attendanceService, IMapper mapper, AttendanceBusinessRules attendanceBusinessRules)
        {
            this.attendanceService = attendanceService;
            this.mapper = mapper;
            _attendanceBusinessRules = attendanceBusinessRules;
        }

        public async Task<CreateAttendanceResponse> Handle(CreateAttendanceCommand request, CancellationToken cancellationToken)
        {
            await _attendanceBusinessRules.EnsureSingleAttendancePerDayAsync(request.StudentId, request.CourseGroupId, request.Date);
            Attendance attendance = mapper.Map<Attendance>(request);
            attendance = await attendanceService.AddAsync(attendance);
            return mapper.Map<CreateAttendanceResponse>(attendance);
        }
    }
}
