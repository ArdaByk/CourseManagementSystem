using AutoMapper;
using CMS.Application.Abstractions.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.StudentCourses.Queries.GetListStudentsByCourseId;

public class GetListStudentsByCourseIdQuery : IRequest<ICollection<GetListStudentsByCourseIdResponse>>
{
    public Guid Id { get; set; }

    public class GetListStudentsByCourseIdQueryHandler : IRequestHandler<GetListStudentsByCourseIdQuery,ICollection<GetListStudentsByCourseIdResponse>>
    {
        private readonly IMapper mapper;
        private readonly IStudentCourseService studentCourseService;

        public GetListStudentsByCourseIdQueryHandler(IMapper mapper, IStudentCourseService studentCourseService)
        {
            this.mapper = mapper;
            this.studentCourseService = studentCourseService;
        }

        public async Task<ICollection<GetListStudentsByCourseIdResponse>> Handle(GetListStudentsByCourseIdQuery request, CancellationToken cancellationToken)
        {
            var studentsWithCourses = await studentCourseService.GetListAsync(predicate: s => s.CourseId == request.Id, include: s => s.Include(s => s.Student), enableTracking: false, cancellationToken: cancellationToken);

            var response = mapper.Map<ICollection<GetListStudentsByCourseIdResponse>>(studentsWithCourses.Select(s => s.Student).ToList());

            return response;
        }
    }
}
