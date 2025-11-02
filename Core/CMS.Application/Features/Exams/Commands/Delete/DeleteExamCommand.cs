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

namespace CMS.Application.Features.Exams.Commands.Delete;

[Authorize(RoleConstants.Admin, RoleConstants.Staff, RoleConstants.Teacher)]
public class DeleteExamCommand : IRequest<DeleteExamResponse>
{
    public Guid Id { get; set; }

    public class DeleteExamCommandHandler : IRequestHandler<DeleteExamCommand, DeleteExamResponse>
    {
        private readonly IExamService examService;
        private readonly IMapper mapper;
        public DeleteExamCommandHandler(IExamService examService, IMapper mapper)
        {
            this.examService = examService;
            this.mapper = mapper;
        }

        public async Task<DeleteExamResponse> Handle(DeleteExamCommand request, CancellationToken cancellationToken)
        {
            Exam exam = await examService.GetAsync(e => e.Id == request.Id, cancellationToken: cancellationToken);

            Exam result = await examService.DeleteAsync(exam);

            DeleteExamResponse response = mapper.Map<DeleteExamResponse>(result);

            return response;
        }
    }
}
