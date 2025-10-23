using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Features.Students.Queries.GetStudentById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Students.Queries.GetStudentByNationalId;

public class GetStudentByNationalIdQuery : IRequest<GetStudentByNationalIdResponse>
{
    public string NationalId { get; set; }

    public class GetStudentByNationalIdQueryHandler : IRequestHandler<GetStudentByNationalIdQuery, GetStudentByNationalIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IStudentService studentService;

        public GetStudentByNationalIdQueryHandler(IMapper mapper, IStudentService studentService)
        {
            this.mapper = mapper;
            this.studentService = studentService;
        }

        public async Task<GetStudentByNationalIdResponse> Handle(GetStudentByNationalIdQuery request, CancellationToken cancellationToken)
        {
            GetStudentByNationalIdResponse response = mapper.Map<GetStudentByNationalIdResponse>(await studentService.GetAsync(predicate: s => s.NationalId.Equals(request.NationalId), enableTracking: false, cancellationToken: cancellationToken));

            return response;
        }
    }
}
