using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.StudentCourses.Commands.Delete;

public class DeleteStudentCourseCommand : IRequest<DeleteStudentCourseResponse>
{
    public Guid Id { get; set; }

    public class DeleteStudentCourseCommandHandler : IRequestHandler<DeleteStudentCourseCommand, DeleteStudentCourseResponse>
    {
        private readonly IStudentCourseService studentCourseService;
        private readonly IMapper mapper;
        public DeleteStudentCourseCommandHandler(IStudentCourseService studentCourseService, IMapper mapper)
        {
            this.studentCourseService = studentCourseService;
            this.mapper = mapper;
        }

        public async Task<DeleteStudentCourseResponse> Handle(DeleteStudentCourseCommand request, CancellationToken cancellationToken)
        {
            StudentCourse studentCourse = await studentCourseService.GetAsync(s => s.Id == request.Id, cancellationToken: cancellationToken);

            StudentCourse result = await studentCourseService.DeleteAsync(studentCourse);

            DeleteStudentCourseResponse response = mapper.Map<DeleteStudentCourseResponse>(result);

            return response;
        }
    }
}
