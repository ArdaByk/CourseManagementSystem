using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Features.Users.Rules;
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
        private readonly UserBusinessRules _userBusinessRules;

        public UpdateUserCommandHandler(IUserService userService, IMapper mapper, UserBusinessRules userBusinessRules)
        {
            this.userService = userService;
            this.mapper = mapper;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.EnsureUserExistsAsync(request.Id);

            User user = await userService.GetAsync(u => u.Id == request.Id, enableTracking: true, cancellationToken: cancellationToken);

            mapper.Map(request, user);

            User result = await userService.UpdateAsync(user);

            UpdateUserResponse response = mapper.Map<UpdateUserResponse>(result);

            return response;
        }
    }
}
