using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Authorization;
using CMS.Application.Features.Teachers.Rules;
using CMS.Domain.Entities;
using MediatR;

namespace CMS.Application.Features.Teachers.Commands.Create;

[Authorize(RoleConstants.Admin, RoleConstants.Staff)]
public class CreateTeacherCommand : IRequest<CreateTeacherResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string SalaryType { get; set; }
    public float SalaryAmount { get; set; }
    public DateTime HiredDate { get; set; }
    public char Status { get; set; }
    public ICollection<Guid> SpecializationIds { get; set; }

    public class Handler : IRequestHandler<CreateTeacherCommand, CreateTeacherResponse>
    {
        private readonly ITeacherService teacherService;
        private readonly IMapper mapper;
        private readonly TeacherBusinessRules _teacherBusinessRules;

        public Handler(ITeacherService teacherService, IMapper mapper, TeacherBusinessRules teacherBusinessRules)
        {
            this.teacherService = teacherService;
            this.mapper = mapper;
            _teacherBusinessRules = teacherBusinessRules;
        }

        public async Task<CreateTeacherResponse> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            await _teacherBusinessRules.EnsureEmailIsUniqueAsync(request.Email);
            await _teacherBusinessRules.EnsurePhoneIsUniqueAsync(request.Phone);
            await _teacherBusinessRules.EnsureSpecializationsExistAsync(request.SpecializationIds);

            Teacher teacher = mapper.Map<Teacher>(request);

            foreach (var specializationId in request.SpecializationIds)
            {
                teacher.TeacherSpecializations.Add(new TeacherSpecialization
                {
                    SpecializationId = specializationId
                });
            }


            teacher = await teacherService.AddAsync(teacher);
            return mapper.Map<CreateTeacherResponse>(teacher);
        }
    }
}


