using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Students.Commands.Create;

public class CreateStudentCommand: IRequest<CreateStudentResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalId { get; set; }
    public char Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string EmergencyContactName { get; set; }
    public string EmergencyContactPhone { get; set; }
    public string EmergencyContactRelation { get; set; }
    public char Status { get; set; }
    public string PhotoPath { get; set; }

    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, CreateStudentResponse>
    {
        private readonly IStudentService studentService;
        private readonly IMapper mapper;

        public CreateStudentCommandHandler(IStudentService studentService, IMapper mapper)
        {
            this.studentService = studentService;
            this.mapper = mapper;
        }

        public async Task<CreateStudentResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            Student student = mapper.Map<Student>(request);

            student = await studentService.AddAsync(student);

            CreateStudentResponse response = mapper.Map<CreateStudentResponse>(student);

            return response;
        }
    }
}
