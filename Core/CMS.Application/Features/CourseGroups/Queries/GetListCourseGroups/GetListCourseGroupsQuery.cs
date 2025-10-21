using AutoMapper;
using CMS.Application.Abstractions.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.CourseGroups.Queries.GetListCourseGroups;

public class GetListCourseGroupsQuery : IRequest<ICollection<GetListCourseGroupsResponse>>
{

    public class GetListCourseGroupsQueryHandler : IRequestHandler<GetListCourseGroupsQuery, ICollection<GetListCourseGroupsResponse>>
    {
        private readonly ICourseGroupService courseGroupService;
        private readonly IMapper mapper;

        public GetListCourseGroupsQueryHandler(ICourseGroupService courseGroupService, IMapper mapper)
        {
            this.courseGroupService = courseGroupService;
            this.mapper = mapper;
        }

        public async Task<ICollection<GetListCourseGroupsResponse>> Handle(GetListCourseGroupsQuery request, CancellationToken cancellationToken)
        {
            ICollection<GetListCourseGroupsResponse> courseGroups = mapper.Map<ICollection<GetListCourseGroupsResponse>>(await courseGroupService.GetListAsync(include: x => x.Include(x => x.Course),enableTracking: false, cancellationToken: cancellationToken));

            return courseGroups;
        }
    }
}
