using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Authorization;
using CMS.Application.Features.ExamResults.Rules;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.ExamResults.Commands.Create;

[Authorize(RoleConstants.Admin, RoleConstants.Staff, RoleConstants.Teacher)]
public class CreateExamResultCommand : IRequest<CreateExamResultResponse>
{
    public int Score { get; set; }
    public char Grade { get; set; }
    public Guid ExamId { get; set; }
    public Guid StudentId { get; set; }

    public class CreateExamResultCommandHandler : IRequestHandler<CreateExamResultCommand, CreateExamResultResponse>
    {
        private readonly IExamResultService examResultService;
        private readonly IMapper mapper;
        private readonly ExamResultBusinessRules _examResultBusinessRules;

        public CreateExamResultCommandHandler(IExamResultService examResultService, IMapper mapper, ExamResultBusinessRules examResultBusinessRules)
        {
            this.examResultService = examResultService;
            this.mapper = mapper;
            _examResultBusinessRules = examResultBusinessRules;
        }

        public async Task<CreateExamResultResponse> Handle(CreateExamResultCommand request, CancellationToken cancellationToken)
        {
            await _examResultBusinessRules.EnsureStudentHasNoExamResultForExamAsync(request.StudentId, request.ExamId);
            ExamResult examResult = mapper.Map<ExamResult>(request);
            
            if(examResult.Score < 50)
            {
                examResult.Grade = 'K';
            } 
            else
            {
                examResult.Grade = 'G';
            }

            examResult = await examResultService.AddAsync(examResult);
            return mapper.Map<CreateExamResultResponse>(examResult);
        }
    }
}
