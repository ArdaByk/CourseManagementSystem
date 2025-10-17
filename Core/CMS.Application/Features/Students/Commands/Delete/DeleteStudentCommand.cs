using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Students.Commands.Delete;

public class DeleteStudentCommand : IRequest<DeleteStudentResponse>
{
    public Guid Id { get; set; }

    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, DeleteStudentResponse>
    {
        private readonly IStudentService studentService;
        private readonly IMapper mapper;
        public DeleteStudentCommandHandler(IStudentService studentService, IMapper mapper)
        {
            this.studentService = studentService;
            this.mapper = mapper;
        }

        public async Task<DeleteStudentResponse> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            Student student = await studentService.GetAsync(s => s.Id == request.Id, cancellationToken: cancellationToken);

            Student result = await studentService.DeleteAsync(student);

            DeleteStudentResponse response = mapper.Map<DeleteStudentResponse>(result);

            return response;
        }
    }
}
