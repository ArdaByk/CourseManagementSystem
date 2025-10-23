using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Features.Courses.Commands.Update;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.StudentCourses.Commands.Update;

public class UpdateStudentCoursesCommand : IRequest<UpdateStudentCoursesResponse>
{
    public Guid Id { get; set; }
    public DateTime RegisteredDate { get; set; }
    public DateTime CompletionDate { get; set; }
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public Guid CourseGroupId { get; set; }
    public char Status { get; set; }

    public class UpdateStudentCoursesCommandHandler : IRequestHandler<UpdateStudentCoursesCommand, UpdateStudentCoursesResponse>
    {
        private readonly IStudentCourseService studentCourseService;
        private readonly IMapper mapper;

        public UpdateStudentCoursesCommandHandler(IStudentCourseService studentCourseService, IMapper mapper)
        {
            this.studentCourseService = studentCourseService;
            this.mapper = mapper;
        }

        public async Task<UpdateStudentCoursesResponse> Handle(UpdateStudentCoursesCommand request, CancellationToken cancellationToken)
        {
            StudentCourse studentCourse = await studentCourseService.GetAsync(s => s.Id == request.Id, enableTracking: true, cancellationToken: cancellationToken);

            mapper.Map(request, studentCourse);

            StudentCourse result = await studentCourseService.UpdateAsync(studentCourse);

            UpdateStudentCoursesResponse response = mapper.Map<UpdateStudentCoursesResponse>(result);

            return response;
        }
    }
}
