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

namespace CMS.Application.Features.ExamResults.Commands.Update;

[Authorize(RoleConstants.Admin, RoleConstants.Staff, RoleConstants.Teacher)]
public class UpdateExamResultCommand : IRequest<UpdateExamResultResponse>
{
    public Guid Id { get; set; }
    public int Score { get; set; }
    public char Grade { get; set; }
    public Guid ExamId { get; set; }
    public Guid StudentId { get; set; }

    public class UpdateExamResultCommandHandler : IRequestHandler<UpdateExamResultCommand, UpdateExamResultResponse>
    {
        private readonly IExamResultService examResultService;
        private readonly IMapper mapper;

        public UpdateExamResultCommandHandler(IExamResultService examResultService, IMapper mapper)
        {
            this.examResultService = examResultService;
            this.mapper = mapper;
        }

        public async Task<UpdateExamResultResponse> Handle(UpdateExamResultCommand request, CancellationToken cancellationToken)
        {
            ExamResult examResult = await examResultService.GetAsync(er => er.Id == request.Id, enableTracking: true, cancellationToken: cancellationToken);

            mapper.Map(request, examResult);

            ExamResult result = await examResultService.UpdateAsync(examResult);

            UpdateExamResultResponse response = mapper.Map<UpdateExamResultResponse>(result);

            return response;
        }
    }
}
