using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CMS.Application.Common.Authorization;

namespace CMS.Application.Features.Students.Queries.GetListStudents;

[Authorize(RoleConstants.Admin, RoleConstants.Staff)]
public class GetListStudentQuery:IRequest<ICollection<GetListStudentResponse>>
{

    public class GetListStudentQueryHandler : IRequestHandler<GetListStudentQuery, ICollection<GetListStudentResponse>>
    {
        private readonly IStudentService studentService;
        private readonly IMapper mapper;

        public GetListStudentQueryHandler(IStudentService studentService, IMapper mapper)
        {
            this.studentService = studentService;
            this.mapper = mapper;
        }

        public async Task<ICollection<GetListStudentResponse>> Handle(GetListStudentQuery request, CancellationToken cancellationToken)
        {
            ICollection<GetListStudentResponse> students = mapper.Map<ICollection<GetListStudentResponse>>(await studentService.GetListAsync(enableTracking: false, cancellationToken: cancellationToken));

            return students;
        }
    }
}
