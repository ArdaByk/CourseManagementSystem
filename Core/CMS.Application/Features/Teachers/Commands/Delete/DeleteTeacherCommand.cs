using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Teachers.Commands.Delete;

public class DeleteTeacherCommand : IRequest<DeleteTeacherResponse>
{
    public Guid Id { get; set; }

    public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand, DeleteTeacherResponse>
    {
        private readonly ITeacherService teacherService;
        private readonly IMapper mapper;
        public DeleteTeacherCommandHandler(ITeacherService teacherService, IMapper mapper)
        {
            this.teacherService = teacherService;
            this.mapper = mapper;
        }

        public async Task<DeleteTeacherResponse> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            Teacher teacher = await teacherService.GetAsync(t => t.Id == request.Id, cancellationToken: cancellationToken);

            Teacher result = await teacherService.DeleteAsync(teacher);

            DeleteTeacherResponse response = mapper.Map<DeleteTeacherResponse>(result);

            return response;
        }
    }
}
