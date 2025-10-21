using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Users.Commands.Update;

public class UpdateUserCommand : IRequest<UpdateUserResponse>
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Guid RoleId { get; set; }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UpdateUserCommandHandler(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User user = await userService.GetAsync(u => u.Id == request.Id, enableTracking: true, cancellationToken: cancellationToken);

            mapper.Map(request, user);

            User result = await userService.UpdateAsync(user);

            UpdateUserResponse response = mapper.Map<UpdateUserResponse>(result);

            return response;
        }
    }
}
