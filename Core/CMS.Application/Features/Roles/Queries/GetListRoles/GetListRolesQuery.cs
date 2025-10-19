using AutoMapper;
using CMS.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Roles.Queries.GetListRoles;

public class GetListRolesQuery : IRequest<ICollection<GetListRolesResponse>>
{

    public class GetListRolesQueryHandler : IRequestHandler<GetListRolesQuery, ICollection<GetListRolesResponse>>
    {
        private readonly IRoleService roleService;
        private readonly IMapper mapper;

        public GetListRolesQueryHandler(IRoleService roleService, IMapper mapper)
        {
            this.roleService = roleService;
            this.mapper = mapper;
        }

        public async Task<ICollection<GetListRolesResponse>> Handle(GetListRolesQuery request, CancellationToken cancellationToken)
        {
            ICollection<GetListRolesResponse> roles = mapper.Map<ICollection<GetListRolesResponse>>(await roleService.GetListAsync(enableTracking: false, cancellationToken: cancellationToken));

            return roles;
        }
    }
}
