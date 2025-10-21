using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Features.Courses.Queries.GetTeacherById;
using CMS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.CourseGroups.Queries.GetCourseGroupById;

public class GetCourseGroupByIdQuery : IRequest<GetCourseGroupByIdResponse>
{
    public Guid Id { get; set; }

    public class GetCourseGroupByIdQueryHandler : IRequestHandler<GetCourseGroupByIdQuery, GetCourseGroupByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICourseGroupService courseGroupService;

        public GetCourseGroupByIdQueryHandler(IMapper mapper, ICourseGroupService courseGroupService)
        {
            this.mapper = mapper;
            this.courseGroupService = courseGroupService;
        }

        public async Task<GetCourseGroupByIdResponse> Handle(GetCourseGroupByIdQuery request, CancellationToken cancellationToken)
        {
            GetCourseGroupByIdResponse response = mapper.Map<GetCourseGroupByIdResponse>(await courseGroupService.GetAsync(predicate: c => c.Id == request.Id, include: x => x.Include(x => x.Course).Include(x => x.Class).Include(x => x.Teacher).Include(x => x.CourseSchedules), enableTracking: false, cancellationToken: cancellationToken));

            return response;
        }
    }
}
