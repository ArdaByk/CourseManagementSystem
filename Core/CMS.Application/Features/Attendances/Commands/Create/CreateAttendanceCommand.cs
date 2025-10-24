using AutoMapper;
using CMS.Application.Abstractions.Services;
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

        public CreateAttendanceCommandHandler(IAttendanceService attendanceService, IMapper mapper)
        {
            this.attendanceService = attendanceService;
            this.mapper = mapper;
        }

        public async Task<CreateAttendanceResponse> Handle(CreateAttendanceCommand request, CancellationToken cancellationToken)
        {
            Attendance attendance = mapper.Map<Attendance>(request);
            attendance = await attendanceService.AddAsync(attendance);
            return mapper.Map<CreateAttendanceResponse>(attendance);
        }
    }
}
