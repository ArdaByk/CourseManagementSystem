using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Authorization;
using CMS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Application.Common.Authentication;

namespace CMS.Application.Features.Attendances.Queries.GetListAttendancesByCourseGroupId;

[Authorize(RoleConstants.Admin, RoleConstants.Teacher, RoleConstants.Staff)]
public class GetListAttendancesByCourseGroupIdQuery : IRequest<ICollection<GetListAttendancesByCourseGroupIdResponse>>
{
    public Guid Id { get; set; }

    public class GetListAttendancesByCourseGroupIdQueryHandler : IRequestHandler<GetListAttendancesByCourseGroupIdQuery, ICollection<GetListAttendancesByCourseGroupIdResponse>>
    {
        private readonly IMapper mapper;
        private readonly IAttendanceService attendanceService;

        public GetListAttendancesByCourseGroupIdQueryHandler(IMapper mapper, IAttendanceService attendanceService)
        {
            this.mapper = mapper;
            this.attendanceService = attendanceService;
        }

        public async Task<ICollection<GetListAttendancesByCourseGroupIdResponse>> Handle(GetListAttendancesByCourseGroupIdQuery request, CancellationToken cancellationToken)
        {
            var attendances = await attendanceService.GetListAsync(predicate: a => a.CourseGroupId == request.Id, include: a => a.Include(a => a.Student), enableTracking: false, cancellationToken: cancellationToken);

            var attendanceGroup = attendances
                .GroupBy(a => a.Date)
                .OrderBy(a => a.Key)
                .Select(a => new GetListAttendancesByCourseGroupIdResponse
                {
                    Key = a.Key,
                    Students = a.Select(s => new GetListAttendancesByCourseGroupIdGroupDto { Id = s.Id, StudentId = s.StudentId, NationalId = s.Student.NationalId, Phone = s.Student.Phone, FirstName = s.Student.FirstName, LastName = s.Student.LastName, Status = s.Status }).ToList(),
                }).ToList();

            return attendanceGroup;
        }
    }
}