using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Exams.Commands.Create;

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

        public CreateExamCommandHandler(IExamService examService, IMapper mapper)
        {
            this.examService = examService;
            this.mapper = mapper;
        }

        public async Task<CreateExamResponse> Handle(CreateExamCommand request, CancellationToken cancellationToken)
        {
            Exam exam = mapper.Map<Exam>(request);
            exam = await examService.AddAsync(exam);
            return mapper.Map<CreateExamResponse>(exam);
        }
    }
}
