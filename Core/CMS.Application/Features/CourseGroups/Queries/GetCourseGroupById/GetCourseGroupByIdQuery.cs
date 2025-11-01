using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Authorization;
using CMS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Application.Common.Authentication;

namespace CMS.Application.Features.CourseGroups.Queries.GetCourseGroupById;

[Authorize(RoleConstants.Admin, RoleConstants.Teacher, RoleConstants.Staff)]
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
            var currentUser = CurrentUserContext.Instance;
            var courseGroup = await courseGroupService.GetAsync(
                predicate: c => c.Id == request.Id,
                include: x => x.Include(x => x.Course).Include(x => x.Class).Include(x => x.Teacher).Include(x => x.CourseSchedules),
                enableTracking: false,
                cancellationToken: cancellationToken
            );

            if (courseGroup == null)
            {
                throw new Exception("Kurs grubu bulunamadı.");
            }

            GetCourseGroupByIdResponse response = mapper.Map<GetCourseGroupByIdResponse>(courseGroup);

            return response;
        }
    }
}
