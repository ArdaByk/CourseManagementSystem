using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.ExamResults.Commands.Create;

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

        public CreateExamResultCommandHandler(IExamResultService examResultService, IMapper mapper)
        {
            this.examResultService = examResultService;
            this.mapper = mapper;
        }

        public async Task<CreateExamResultResponse> Handle(CreateExamResultCommand request, CancellationToken cancellationToken)
        {
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
