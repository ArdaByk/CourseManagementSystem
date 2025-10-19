using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Exams.Commands.Update;

public class UpdateExamCommand : IRequest<UpdateExamResponse>
{
    public Guid Id { get; set; }
    public string ExamName { get; set; }
    public DateTime ExamDate { get; set; }
    public int MaxScore { get; set; }
    public Guid CourseId { get; set; }

    public class UpdateExamCommandHandler : IRequestHandler<UpdateExamCommand, UpdateExamResponse>
    {
        private readonly IExamService examService;
        private readonly IMapper mapper;

        public UpdateExamCommandHandler(IExamService examService, IMapper mapper)
        {
            this.examService = examService;
            this.mapper = mapper;
        }

        public async Task<UpdateExamResponse> Handle(UpdateExamCommand request, CancellationToken cancellationToken)
        {
            Exam exam = await examService.GetAsync(e => e.Id == request.Id, enableTracking: false, cancellationToken: cancellationToken);

            exam = mapper.Map(request, exam);

            Exam result = await examService.UpdateAsync(exam);

            UpdateExamResponse response = mapper.Map<UpdateExamResponse>(result);

            return response;
        }
    }
}
