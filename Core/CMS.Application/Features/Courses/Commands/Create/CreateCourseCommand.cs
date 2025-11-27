using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Domain.Entities;
using MediatR;
using CMS.Application.Features.Courses.Rules;

using CMS.Application.Common.Authorization;

namespace CMS.Application.Features.Courses.Commands.Create;

[Authorize(RoleConstants.Admin, RoleConstants.Staff)]
public class CreateCourseCommand : IRequest<CreateCourseResponse>
{
    public string CourseName { get; set; }
    public string Description { get; set; }
    public int DurationWeeks { get; set; }
    public int WeeklyHours { get; set; }
    public char Status { get; set; }
    public Guid SpecializationId { get; set; }


    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, CreateCourseResponse>
    {
        private readonly ICourseService courseService;
        private readonly IMapper mapper;
        private readonly CourseBusinessRules _courseBusinessRules;

        public CreateCourseCommandHandler(ICourseService courseService, IMapper mapper, CourseBusinessRules courseBusinessRules)
        {
            this.courseService = courseService;
            this.mapper = mapper;
            _courseBusinessRules = courseBusinessRules;
        }

        public async Task<CreateCourseResponse> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            await _courseBusinessRules.EnsureCourseNameIsUniqueAsync(request.CourseName);
            _courseBusinessRules.EnsureWeeklyHoursInLimit(request.WeeklyHours);
            Course course = mapper.Map<Course>(request);
            course = await courseService.AddAsync(course);
            return mapper.Map<CreateCourseResponse>(course);
        }
    }
}


