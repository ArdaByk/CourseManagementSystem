using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Authorization;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.ExamResults.Commands.Delete;

[Authorize(RoleConstants.Admin, RoleConstants.Staff, RoleConstants.Teacher)]
public class DeleteExamResultCommand : IRequest<DeleteExamResultResponse>
{
    public Guid Id { get; set; }

    public class DeleteExamResultCommandHandler : IRequestHandler<DeleteExamResultCommand, DeleteExamResultResponse>
    {
        private readonly IExamResultService examResultService;
        private readonly IMapper mapper;
        public DeleteExamResultCommandHandler(IExamResultService examResultService, IMapper mapper)
        {
            this.examResultService = examResultService;
            this.mapper = mapper;
        }

        public async Task<DeleteExamResultResponse> Handle(DeleteExamResultCommand request, CancellationToken cancellationToken)
        {
            ExamResult examResult = await examResultService.GetAsync(er => er.Id == request.Id, cancellationToken: cancellationToken);

            ExamResult result = await examResultService.DeleteAsync(examResult);

            DeleteExamResultResponse response = mapper.Map<DeleteExamResultResponse>(result);

            return response;
        }
    }
}
