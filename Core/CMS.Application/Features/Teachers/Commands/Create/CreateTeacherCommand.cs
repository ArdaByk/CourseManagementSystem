using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Domain.Entities;
using MediatR;

namespace CMS.Application.Features.Teachers.Commands.Create;

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

    public class Handler : IRequestHandler<CreateTeacherCommand, CreateTeacherResponse>
    {
        private readonly ITeacherService teacherService;
        private readonly IMapper mapper;

        public Handler(ITeacherService teacherService, IMapper mapper)
        {
            this.teacherService = teacherService;
            this.mapper = mapper;
        }

        public async Task<CreateTeacherResponse> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            Teacher teacher = mapper.Map<Teacher>(request);
            teacher = await teacherService.AddAsync(teacher);
            return mapper.Map<CreateTeacherResponse>(teacher);
        }
    }
}


