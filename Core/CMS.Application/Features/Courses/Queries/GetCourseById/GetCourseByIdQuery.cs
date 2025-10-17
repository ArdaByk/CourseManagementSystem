using AutoMapper;
using CMS.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Courses.Queries.GetTeacherById;

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
            GetCourseByIdResponse response = mapper.Map<GetCourseByIdResponse>(await courseService.GetAsync(predicate: c => c.Id == request.Id, enableTracking: false, cancellationToken: cancellationToken));

            return response;
        }
    }
}
