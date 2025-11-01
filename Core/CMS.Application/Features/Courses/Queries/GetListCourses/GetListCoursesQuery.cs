using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Authentication;
using CMS.Application.Common.Authorization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Courses.Queries.GetListTeachers;

[Authorize(RoleConstants.Admin, RoleConstants.Teacher, RoleConstants.Staff)]
public class GetListCoursesQuery : IRequest<ICollection<GetListCoursesResponse>>
{

    public class GetListCoursesQueryHandler : IRequestHandler<GetListCoursesQuery, ICollection<GetListCoursesResponse>>
    {
        private readonly ICourseService courseService;
        private readonly IMapper mapper;

        public GetListCoursesQueryHandler(ICourseService courseService, IMapper mapper)
        {
            this.courseService = courseService;
            this.mapper = mapper;
        }

        public async Task<ICollection<GetListCoursesResponse>> Handle(GetListCoursesQuery request, CancellationToken cancellationToken)
        {
            ICollection<GetListCoursesResponse> courses = mapper.Map<ICollection<GetListCoursesResponse>>(await courseService.GetListAsync(enableTracking: false, cancellationToken: cancellationToken));

            return courses;
        }
    }
}