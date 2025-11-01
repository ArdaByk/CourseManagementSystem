using AutoMapper;
using CMS.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CMS.Application.Common.Authorization;

namespace CMS.Application.Features.Classes.Queries.GetListClasses;

[Authorize(RoleConstants.Admin, RoleConstants.Staff)]
public class GetListClassesQuery : IRequest<ICollection<GetListClassesResponse>>
{

    public class GetListClassesQueryHandler : IRequestHandler<GetListClassesQuery, ICollection<GetListClassesResponse>>
    {
        private readonly IClassService classService;
        private readonly IMapper mapper;

        public GetListClassesQueryHandler(IClassService classService, IMapper mapper)
        {
            this.classService = classService;
            this.mapper = mapper;
        }

        public async Task<ICollection<GetListClassesResponse>> Handle(GetListClassesQuery request, CancellationToken cancellationToken)
        {
            ICollection<GetListClassesResponse> classes = mapper.Map<ICollection<GetListClassesResponse>>(await classService.GetListAsync(enableTracking: false, cancellationToken: cancellationToken));

            return classes;
        }
    }
}
