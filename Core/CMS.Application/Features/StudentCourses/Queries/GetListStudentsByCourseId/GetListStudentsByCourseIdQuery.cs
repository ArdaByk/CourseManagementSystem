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

namespace CMS.Application.Features.StudentCourses.Queries.GetListStudentsByCourseId;

[Authorize(RoleConstants.Admin, RoleConstants.Teacher, RoleConstants.Staff)]
public class GetListStudentsByCourseIdQuery : IRequest<ICollection<GetListStudentsByCourseIdResponse>>
{
    public Guid Id { get; set; }

    public class GetListStudentsByCourseIdQueryHandler : IRequestHandler<GetListStudentsByCourseIdQuery,ICollection<GetListStudentsByCourseIdResponse>>
    {
        private readonly IMapper mapper;
        private readonly IStudentCourseService studentCourseService;
        private readonly ICourseGroupService courseGroupService;
        private readonly ITeacherService teacherService;

        public GetListStudentsByCourseIdQueryHandler(IMapper mapper, IStudentCourseService studentCourseService, ICourseGroupService courseGroupService, ITeacherService teacherService)
        {
            this.mapper = mapper;
            this.studentCourseService = studentCourseService;
            this.courseGroupService = courseGroupService;
            this.teacherService = teacherService;
        }

        public async Task<ICollection<GetListStudentsByCourseIdResponse>> Handle(GetListStudentsByCourseIdQuery request, CancellationToken cancellationToken)
        {
            var currentUser = CurrentUserContext.Instance;

            // Öğretmen sadece kendi kurslarının öğrencilerini görebilir
            if (currentUser.RoleName == RoleConstants.Teacher)
            {
                var teacherId = await AuthorizationHelper.GetTeacherIdFromCurrentUserAsync(teacherService);
                if (teacherId.HasValue)
                {
                    // Öğretmenin kurs gruplarını al
                    var courseGroups = await courseGroupService.GetListAsync(
                        predicate: cg => cg.TeacherId == teacherId.Value && cg.CourseId == request.Id,
                        enableTracking: false,
                        cancellationToken: cancellationToken
                    );

                    if (!courseGroups.Any())
                    {
                        throw new UnauthorizedAccessException("Bu kursa erişim yetkiniz bulunmamaktadır.");
                    }
                }
            }

            var studentsWithCourses = await studentCourseService.GetListAsync(
                predicate: s => s.CourseId == request.Id,
                include: s => s.Include(s => s.Student),
                enableTracking: false,
                cancellationToken: cancellationToken
            );

            var response = mapper.Map<ICollection<GetListStudentsByCourseIdResponse>>(studentsWithCourses.Select(s => s.Student).ToList());

            return response;
        }
    }
}
