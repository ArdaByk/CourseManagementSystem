using AutoMapper;
using CMS.Application.Abstractions.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Users.Queries.GetListUsers;

public class GetListUsersQuery : IRequest<ICollection<GetListUsersResponse>>
{

    public class GetListUsersQueryHandler : IRequestHandler<GetListUsersQuery, ICollection<GetListUsersResponse>>
    { 
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public GetListUsersQueryHandler(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        public async Task<ICollection<GetListUsersResponse>> Handle(GetListUsersQuery request, CancellationToken cancellationToken)
        {
            ICollection<GetListUsersResponse> users = mapper.Map<ICollection<GetListUsersResponse>>(await userService.GetListAsync(enableTracking: false,include: u => u.Include(u => u.Role) ,cancellationToken: cancellationToken));

            return users;
        }
    }
}
