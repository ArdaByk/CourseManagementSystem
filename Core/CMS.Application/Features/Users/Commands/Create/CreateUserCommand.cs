using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Security.Hashing;
using CMS.Application.Features.Users.Rules;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Users.Commands.Create;

public class CreateUserCommand : IRequest<CreateUserResponse>
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Guid RoleId { get; set; }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly UserBusinessRules _userBusinessRules;

        public CreateUserCommandHandler(IUserService userService, IMapper mapper, UserBusinessRules userBusinessRules)
        {
            this.userService = userService;
            this.mapper = mapper;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.EnsureUsernameIsUniqueAsync(request.Username);
            await _userBusinessRules.EnsureEmailIsUniqueAsync(request.Email);

            User user = mapper.Map<User>(request);

            byte[] passwordHash;
            byte[] passwordSalt;

            HashingHelper.HashPassword(request.Password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            user = await userService.AddAsync(user);

            return mapper.Map<CreateUserResponse>(user);
        }
    }
}
