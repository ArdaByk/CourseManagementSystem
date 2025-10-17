using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Features.Students.Queries.GetStudentById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Teachers.Queries.GetTeacherById;

public class GetTeacherByIdQuery : IRequest<GetTeacherByIdResponse>
{
    public Guid Id { get; set; }

    public class GetTeacherByIdQueryHandler : IRequestHandler<GetTeacherByIdQuery, GetTeacherByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ITeacherService teacherService;

        public GetTeacherByIdQueryHandler(IMapper mapper, ITeacherService teacherService)
        {
            this.mapper = mapper;
            this.teacherService = teacherService;
        }

        public async Task<GetTeacherByIdResponse> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
        {
            GetTeacherByIdResponse response = mapper.Map<GetTeacherByIdResponse>(await teacherService.GetAsync(predicate: t => t.Id == request.Id, enableTracking: false, cancellationToken: cancellationToken));

            return response;
        }
    }
}
