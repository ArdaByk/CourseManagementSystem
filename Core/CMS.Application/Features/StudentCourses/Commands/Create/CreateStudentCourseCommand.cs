using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Authorization;
using CMS.Application.Features.Courses.Commands.Create;
using CMS.Application.Features.StudentCourses.Rules;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.StudentCourses.Commands.Create;

[Authorize(RoleConstants.Admin, RoleConstants.Staff)]
public class CreateStudentCourseCommand : IRequest<CreateStudentCourseResponse>
{
    public DateTime RegisteredDate { get; set; }
    public DateTime CompletionDate { get; set; }
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public Guid CourseGroupId { get; set; }
    public char Status { get; set; }

    public class CreateStudentCourseCommandHandler : IRequestHandler<CreateStudentCourseCommand, CreateStudentCourseResponse>
    {
        private readonly IStudentCourseService studentCourseService;
        private readonly IMapper mapper;
        private readonly StudentCourseBusinessRules _studentCourseBusinessRules;

        public CreateStudentCourseCommandHandler(IStudentCourseService studentCourseService, IMapper mapper, StudentCourseBusinessRules studentCourseBusinessRules)
        {
            this.studentCourseService = studentCourseService;
            this.mapper = mapper;
            _studentCourseBusinessRules = studentCourseBusinessRules;
        }

        public async Task<CreateStudentCourseResponse> Handle(CreateStudentCourseCommand request, CancellationToken cancellationToken)
        {
            await _studentCourseBusinessRules.EnsureStudentNotExistsInCourseGroupAsync(request.StudentId, request.CourseGroupId);
            StudentCourse studentCourse = mapper.Map<StudentCourse>(request);
            studentCourse = await studentCourseService.AddAsync(studentCourse);
            return mapper.Map<CreateStudentCourseResponse>(studentCourse);
        }
    }
}
