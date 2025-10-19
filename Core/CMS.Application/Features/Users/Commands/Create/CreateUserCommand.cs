using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Security.Hashing;
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

        public CreateUserCommandHandler(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
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
