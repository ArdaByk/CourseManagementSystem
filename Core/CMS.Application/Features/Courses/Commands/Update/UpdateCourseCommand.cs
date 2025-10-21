using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Features.Teachers.Commands.Update;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Courses.Commands.Update;

public class UpdateCourseCommand : IRequest<UpdateCourseResponse>
{
    public Guid Id { get; set; }
    public string CourseName { get; set; }
    public string Description { get; set; }
    public int DurationWeeks { get; set; }
    public int WeeklyHours { get; set; }
    public char Status { get; set; }

    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, UpdateCourseResponse>
    {
        private readonly ICourseService courseService;
        private readonly IMapper mapper;

        public UpdateCourseCommandHandler(ICourseService courseService, IMapper mapper)
        {
            this.courseService = courseService;
            this.mapper = mapper;
        }

        public async Task<UpdateCourseResponse> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            Course course = await courseService.GetAsync(c => c.Id == request.Id, enableTracking: true, cancellationToken: cancellationToken);

            mapper.Map(request, course);

            Course result = await courseService.UpdateAsync(course);

            UpdateCourseResponse response = mapper.Map<UpdateCourseResponse>(result);

            return response;
        }
    }
}
