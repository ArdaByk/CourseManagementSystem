using AutoMapper;
using CMS.Application.Abstractions.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.StudentCourses.Queries.GetListStudentsByCourseGroupId;

public class GetListStudentsByCourseGroupIdQuery : IRequest<ICollection<GetListStudentsByCourseGroupIdResponse>>
{
    public Guid Id { get; set; }

    public class GetListStudentsByCourseIdQueryHandler : IRequestHandler<GetListStudentsByCourseGroupIdQuery, ICollection<GetListStudentsByCourseGroupIdResponse>>
    {
        private readonly IMapper mapper;
        private readonly IStudentCourseService studentCourseService;

        public GetListStudentsByCourseIdQueryHandler(IMapper mapper, IStudentCourseService studentCourseService)
        {
            this.mapper = mapper;
            this.studentCourseService = studentCourseService;
        }

        public async Task<ICollection<GetListStudentsByCourseGroupIdResponse>> Handle(GetListStudentsByCourseGroupIdQuery request, CancellationToken cancellationToken)
        {
            var studentsWithCourses = await studentCourseService.GetListAsync(predicate: s => s.CourseGroupId == request.Id, include: s => s.Include(s => s.Student) ,enableTracking: false, cancellationToken: cancellationToken);

            var response = mapper.Map<ICollection<GetListStudentsByCourseGroupIdResponse>>(studentsWithCourses.Select(s => s.Student).ToList());

            return response;
        }
    }
}