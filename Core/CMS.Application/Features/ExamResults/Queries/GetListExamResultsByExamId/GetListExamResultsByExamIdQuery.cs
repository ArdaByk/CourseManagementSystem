using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Authorization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.ExamResults.Queries.GetListExamResultsByExamId;

[Authorize(RoleConstants.Admin, RoleConstants.Teacher, RoleConstants.Staff)]
public class GetListExamResultsByExamIdQuery : IRequest<ICollection<GetListExamResultsByExamIdResponse>>
{
    public Guid Id { get; set; }

    public class GetListExamResultsByExamIdQueryHandler : IRequestHandler<GetListExamResultsByExamIdQuery, ICollection<GetListExamResultsByExamIdResponse>>
    {
        private readonly IMapper mapper;
        private readonly IExamResultService examResultService;

        public GetListExamResultsByExamIdQueryHandler(IMapper mapper, IExamResultService examResultService)
        {
            this.mapper = mapper;
            this.examResultService = examResultService;
        }

        public async Task<ICollection<GetListExamResultsByExamIdResponse>> Handle(GetListExamResultsByExamIdQuery request, CancellationToken cancellationToken)
        {
            ICollection<GetListExamResultsByExamIdResponse> response = mapper.Map<ICollection<GetListExamResultsByExamIdResponse>>(await examResultService.GetListAsync(predicate: er => er.ExamId == request.Id, include: er => er.Include(er => er.Student) ,enableTracking: false, cancellationToken: cancellationToken));

            return response;
        }
    }
}
