using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.CourseGroups.Queries.GetListCourseGroupsByCourseId;

[Authorize(RoleConstants.Admin, RoleConstants.Teacher, RoleConstants.Staff)]
public class GetListCourseGroupsByCourseIdQuery : IRequest<ICollection<GetListCourseGroupsByCourseIdResponse>>
{
    public Guid Id { get; set; }

    public class GetListCourseGroupsByCourseIdQueryHandler : IRequestHandler<GetListCourseGroupsByCourseIdQuery, ICollection<GetListCourseGroupsByCourseIdResponse>>
    {
        private readonly IMapper mapper;
        private readonly ICourseGroupService courseGroupService;

        public GetListCourseGroupsByCourseIdQueryHandler(IMapper mapper, ICourseGroupService courseGroupService)
        {
            this.mapper = mapper;
            this.courseGroupService = courseGroupService;
        }

        public async Task<ICollection<GetListCourseGroupsByCourseIdResponse>> Handle(GetListCourseGroupsByCourseIdQuery request, CancellationToken cancellationToken)
        {
            ICollection<GetListCourseGroupsByCourseIdResponse> response = mapper.Map<ICollection<GetListCourseGroupsByCourseIdResponse>>(await courseGroupService.GetAsync(predicate: c => c.CourseId == request.Id, enableTracking: false, cancellationToken: cancellationToken));

            return response;
        }
    }
}
