using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Authorization;
using CMS.Application.Features.Teachers.Commands.Update;
using CMS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Teachers.Commands.Update;

[Authorize(RoleConstants.Admin, RoleConstants.Staff)]
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
    public ICollection<Guid> SelectedIds { get; set; }

    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, UpdateTeacherResponse>
    {
        private readonly ITeacherService teacherService;
        private readonly ITeacherSpecializationService teacherSpecializationService;
        private readonly IMapper mapper;

        public UpdateTeacherCommandHandler(ITeacherService teacherService, IMapper mapper, ITeacherSpecializationService teacherSpecializationService)
        {
            this.teacherService = teacherService;
            this.mapper = mapper;
            this.teacherSpecializationService = teacherSpecializationService;
        }

        public async Task<UpdateTeacherResponse> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            Teacher teacher = await teacherService.GetAsync(
                t => t.Id == request.Id,
                include: x => x.Include(x => x.TeacherSpecializations),
                enableTracking: true,
                cancellationToken: cancellationToken);

            mapper.Map(request, teacher);

            var currentIds = teacher.TeacherSpecializations.Select(ts => ts.SpecializationId).ToList();

            var toAdd = request.SelectedIds
                .Where(id => !currentIds.Contains(id))
                .Select(id => new TeacherSpecialization
                {
                    TeacherId = teacher.Id,
                    SpecializationId = id
                })
                .ToList();

            var toRemove = teacher.TeacherSpecializations
                .Where(ts => !request.SelectedIds.Contains(ts.SpecializationId))
                .ToList();

            foreach (var item in toRemove)
                teacher.TeacherSpecializations.Remove(item);

            foreach (var item in toAdd)
                teacher.TeacherSpecializations.Add(item);

            Teacher result = await teacherService.UpdateAsync(teacher);

            UpdateTeacherResponse response = mapper.Map<UpdateTeacherResponse>(result);

            return response;
        }

    }
}
