using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Domain.Entities;
using MediatR;

namespace CMS.Application.Features.Courses.Commands.Create;

public class CreateCourseCommand : IRequest<CreateCourseResponse>
{
    public string CourseName { get; set; }
    public string Description { get; set; }
    public int DurationWeeks { get; set; }
    public int WeeklyHours { get; set; }
    public char Status { get; set; }


    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, CreateCourseResponse>
    {
        private readonly ICourseService courseService;
        private readonly IMapper mapper;

        public CreateCourseCommandHandler(ICourseService courseService, IMapper mapper)
        {
            this.courseService = courseService;
            this.mapper = mapper;
        }

        public async Task<CreateCourseResponse> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            Course course = mapper.Map<Course>(request);
            course = await courseService.AddAsync(course);
            return mapper.Map<CreateCourseResponse>(course);
        }
    }
}


