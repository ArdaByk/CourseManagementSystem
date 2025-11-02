using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Exams.Queries.GetExamById;

[Authorize(RoleConstants.Admin, RoleConstants.Teacher, RoleConstants.Staff)]
public class GetExamByIdQuery : IRequest<GetExamByIdResponse>
{
    public Guid Id { get; set; }

    public class GetExamByIdQueryHandler : IRequestHandler<GetExamByIdQuery, GetExamByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IExamService examService;

        public GetExamByIdQueryHandler(IMapper mapper, IExamService examService)
        {
            this.mapper = mapper;
            this.examService = examService;
        }

        public async Task<GetExamByIdResponse> Handle(GetExamByIdQuery request, CancellationToken cancellationToken)
        {
            GetExamByIdResponse response = mapper.Map<GetExamByIdResponse>(await examService.GetAsync(predicate: e => e.Id == request.Id, enableTracking: false, cancellationToken: cancellationToken));

            return response;
        }
    }
}
