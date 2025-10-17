using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Features.Students.Queries.GetListStudents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Teachers.Queries.GetListTeachers;

public class GetListTeacherQuery : IRequest<ICollection<GetListTeacherResponse>>
{

    public class GetListTeacherQueryHandler : IRequestHandler<GetListTeacherQuery, ICollection<GetListTeacherResponse>>
    {
        private readonly ITeacherService teacherService;
        private readonly IMapper mapper;

        public GetListTeacherQueryHandler(ITeacherService teacherService, IMapper mapper)
        {
            this.teacherService = teacherService;
            this.mapper = mapper;
        }

        public async Task<ICollection<GetListTeacherResponse>> Handle(GetListTeacherQuery request, CancellationToken cancellationToken)
        {
            ICollection<GetListTeacherResponse> teachers = mapper.Map<ICollection<GetListTeacherResponse>>(await teacherService.GetListAsync(enableTracking: false, cancellationToken: cancellationToken));

            return teachers;
        }
    }
}
