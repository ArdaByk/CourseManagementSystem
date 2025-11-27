using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Features.Teachers.Queries.GetListTeachers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Teachers.Queries.GetListTeachersBySpecializationId;

public class GetListTeachersBySpecializationId : IRequest<ICollection<GetListTeachersBySpecializationIdResponse>>
{
    public Guid SpecializationId { get; set; }

    public class GetListTeachersBySpecializationIdHandler : IRequestHandler<GetListTeachersBySpecializationId, ICollection<GetListTeachersBySpecializationIdResponse>>
    {
        private readonly ITeacherService teacherService;
        private readonly IMapper mapper;

        public GetListTeachersBySpecializationIdHandler(ITeacherService teacherService, IMapper mapper)
        {
            this.teacherService = teacherService;
            this.mapper = mapper;
        }

        public async Task<ICollection<GetListTeachersBySpecializationIdResponse>> Handle(GetListTeachersBySpecializationId request, CancellationToken cancellationToken)
        {
            var teacherList = await teacherService.GetListAsync(
                enableTracking: false,
                include: t => t.Include(t => t.TeacherSpecializations),
                predicate: t => t.TeacherSpecializations.Any(ts => ts.SpecializationId == request.SpecializationId),
                cancellationToken: cancellationToken);

            return mapper.Map<ICollection<GetListTeachersBySpecializationIdResponse>>(teacherList);
        }

    }
}
