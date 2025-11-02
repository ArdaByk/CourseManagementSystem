using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Authorization;
using CMS.Application.Features.Courses.Queries.GetTeacherById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Classes.Queries.GetClassById;

[Authorize(RoleConstants.Admin, RoleConstants.Teacher, RoleConstants.Staff)]
public class GetClassByIdQuery:IRequest<GetClassByIdResponse>
{
    public Guid Id { get; set; }

    public class GetClassByIdQueryHandler : IRequestHandler<GetClassByIdQuery, GetClassByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IClassService classService;

        public GetClassByIdQueryHandler(IMapper mapper, IClassService classService)
        {
            this.mapper = mapper;
            this.classService = classService;
        }

        public async Task<GetClassByIdResponse> Handle(GetClassByIdQuery request, CancellationToken cancellationToken)
        {
            GetClassByIdResponse response = mapper.Map<GetClassByIdResponse>(await classService.GetAsync(predicate: c => c.Id == request.Id, enableTracking: false, cancellationToken: cancellationToken));

            return response;
        }
    }
}
