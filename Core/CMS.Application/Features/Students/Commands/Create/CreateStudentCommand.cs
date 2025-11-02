using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Authorization;
using CMS.Application.Features.Students.Rules;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Students.Commands.Create;

[Authorize(RoleConstants.Admin, RoleConstants.Staff)]
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
        private readonly StudentBusinessRules _studentBusinessRules;

        public CreateStudentCommandHandler(IStudentService studentService, IMapper mapper, StudentBusinessRules studentBusinessRules)
        {
            this.studentService = studentService;
            this.mapper = mapper;
            _studentBusinessRules = studentBusinessRules;
        }

        public async Task<CreateStudentResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            await _studentBusinessRules.EnsureNationalIdIsUniqueAsync(request.NationalId);
            await _studentBusinessRules.EnsureEmailIsUniqueAsync(request.Email);

            Student student = mapper.Map<Student>(request);

            student = await studentService.AddAsync(student);

            CreateStudentResponse response = mapper.Map<CreateStudentResponse>(student);

            return response;
        }
    }
}
