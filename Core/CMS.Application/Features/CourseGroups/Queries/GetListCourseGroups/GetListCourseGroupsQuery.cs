using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Authorization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.CourseGroups.Queries.GetListCourseGroups;

[Authorize(RoleConstants.Admin, RoleConstants.Teacher, RoleConstants.Staff)]
public class GetListCourseGroupsQuery : IRequest<ICollection<GetListCourseGroupsResponse>>
{
    public class GetListCourseGroupsQueryHandler : IRequestHandler<GetListCourseGroupsQuery, ICollection<GetListCourseGroupsResponse>>
    {
        private readonly ICourseGroupService courseGroupService;
        private readonly ITeacherService teacherService;
        private readonly IMapper mapper;

        public GetListCourseGroupsQueryHandler(ICourseGroupService courseGroupService, ITeacherService teacherService, IMapper mapper)
        {
            this.courseGroupService = courseGroupService;
            this.teacherService = teacherService;
            this.mapper = mapper;
        }

        public async Task<ICollection<GetListCourseGroupsResponse>> Handle(GetListCourseGroupsQuery request, CancellationToken cancellationToken)
        {
            var allCourseGroups = await courseGroupService.GetListAsync(
                include: x => x.Include(x => x.Course),
                enableTracking: false,
                cancellationToken: cancellationToken
            );
            return mapper.Map<ICollection<GetListCourseGroupsResponse>>(allCourseGroups);
        }
    }
}
