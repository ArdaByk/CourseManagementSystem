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

namespace CMS.Application.Features.Courses.Queries.GetTeacherById;

[Authorize(RoleConstants.Admin, RoleConstants.Teacher, RoleConstants.Staff)]
public class GetCourseByIdQuery : IRequest<GetCourseByIdResponse>
{
    public Guid Id { get; set; }

    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, GetCourseByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICourseService courseService;

        public GetCourseByIdQueryHandler(IMapper mapper, ICourseService courseService)
        {
            this.mapper = mapper;
            this.courseService = courseService;
        }

        public async Task<GetCourseByIdResponse> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            GetCourseByIdResponse response = mapper.Map<GetCourseByIdResponse>(await courseService.GetAsync(
                predicate: c => c.Id == request.Id,
                include: c => c.Include(c => c.Specialization),
                enableTracking: true,
                cancellationToken: cancellationToken));

            return response;
        }
    }
}
