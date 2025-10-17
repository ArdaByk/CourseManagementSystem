using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Features.Teachers.Commands.Update;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Teachers.Commands.Update;

public class UpdateTeacherCommand : IRequest<UpdateTeacherResponse>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string SalaryType { get; set; }
    public float SalaryAmount { get; set; }
    public DateTime HiredDate { get; set; }
    public char Status { get; set; }

    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, UpdateTeacherResponse>
    {
        private readonly ITeacherService teacherService;
        private readonly IMapper mapper;

        public UpdateTeacherCommandHandler(ITeacherService teacherService, IMapper mapper)
        {
            this.teacherService = teacherService;
            this.mapper = mapper;
        }

        public async Task<UpdateTeacherResponse> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            Teacher teacher = await teacherService.GetAsync(t => t.Id == request.Id, enableTracking: false, cancellationToken: cancellationToken);

            teacher = mapper.Map(request, teacher);

            Teacher result = await teacherService.UpdateAsync(teacher);

            UpdateTeacherResponse response = mapper.Map<UpdateTeacherResponse>(result);

            return response;
        }
    }
}
