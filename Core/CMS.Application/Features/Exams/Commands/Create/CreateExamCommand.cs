using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Authorization;
using CMS.Application.Features.Exams.Rules;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Exams.Commands.Create;

[Authorize(RoleConstants.Admin, RoleConstants.Staff, RoleConstants.Teacher)]
public class CreateExamCommand : IRequest<CreateExamResponse>
{
    public string ExamName { get; set; }
    public DateTime ExamDate { get; set; }
    public int MaxScore { get; set; }
    public Guid CourseId { get; set; }

    public class CreateExamCommandHandler : IRequestHandler<CreateExamCommand, CreateExamResponse>
    {
        private readonly IExamService examService;
        private readonly IMapper mapper;
        private readonly ExamBusinessRules _examBusinessRules;

        public CreateExamCommandHandler(IExamService examService, IMapper mapper, ExamBusinessRules examBusinessRules)
        {
            this.examService = examService;
            this.mapper = mapper;
            _examBusinessRules = examBusinessRules;
        }

        public async Task<CreateExamResponse> Handle(CreateExamCommand request, CancellationToken cancellationToken)
        {
            await _examBusinessRules.EnsureCourseExistsAsync(request.CourseId);
            await _examBusinessRules.EnsureNoDuplicateExamAsync(request.ExamName, request.CourseId, request.ExamDate);
            _examBusinessRules.EnsureExamDateNotPast(request.ExamDate);

            Exam exam = mapper.Map<Exam>(request);
            exam = await examService.AddAsync(exam);
            return mapper.Map<CreateExamResponse>(exam);
        }
    }
}
