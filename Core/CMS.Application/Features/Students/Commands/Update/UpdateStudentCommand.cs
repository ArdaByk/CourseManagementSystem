using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Authorization;
using CMS.Application.Features.Students.Commands.Create;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Students.Commands.Update;

[Authorize(RoleConstants.Admin, RoleConstants.Staff)]
public class UpdateStudentCommand: IRequest<UpdateStudentResponse>
{
    public Guid Id { get; set; }
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

    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, UpdateStudentResponse>
    {
        private readonly IStudentService studentService;
        private readonly IMapper mapper;

        public UpdateStudentCommandHandler(IStudentService studentService, IMapper mapper)
        {
            this.studentService = studentService;
            this.mapper = mapper;
        }

        public async Task<UpdateStudentResponse> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            Student student = await studentService.GetAsync(s => s.Id == request.Id, enableTracking: true, cancellationToken: cancellationToken);

            mapper.Map(request, student);

            Student result = await studentService.UpdateAsync(student);

            UpdateStudentResponse response = mapper.Map<UpdateStudentResponse>(result);

            return response; ;
        }
    }
}
