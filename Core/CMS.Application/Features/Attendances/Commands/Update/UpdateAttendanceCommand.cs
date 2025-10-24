using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Attendances.Commands.Update;

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
        private readonly IMapper mapper;

        public UpdateAttendanceCommandHandler(IAttendanceService attendanceService, IMapper mapper)
        {
            this.attendanceService = attendanceService;
            this.mapper = mapper;
        }

        public async Task<UpdateAttendanceResponse> Handle(UpdateAttendanceCommand request, CancellationToken cancellationToken)
        {
            Attendance attendance = await attendanceService.GetAsync(a => a.Id == request.Id, enableTracking: true, cancellationToken: cancellationToken);

            mapper.Map(request, attendance);

            Attendance result = await attendanceService.UpdateAsync(attendance);

            UpdateAttendanceResponse response = mapper.Map<UpdateAttendanceResponse>(result);

            return response;
        }
    }
}
