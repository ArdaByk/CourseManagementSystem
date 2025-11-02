using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Students.Queries.GetStudentById;

[Authorize(RoleConstants.Admin, RoleConstants.Teacher, RoleConstants.Staff)]
public class GetStudentByIdQuery: IRequest<GetStudentByIdResponse>
{
    public Guid Id { get; set; }

    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, GetStudentByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IStudentService studentService;

        public GetStudentByIdQueryHandler(IMapper mapper, IStudentService studentService)
        {
            this.mapper = mapper;
            this.studentService = studentService;
        }

        public async Task<GetStudentByIdResponse> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            GetStudentByIdResponse response = mapper.Map<GetStudentByIdResponse>(await studentService.GetAsync(predicate: s => s.Id == request.Id, enableTracking: false, cancellationToken: cancellationToken));

            return response;
        }
    }
}
