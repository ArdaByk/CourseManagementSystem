using AutoMapper;
using CMS.Application.Abstractions.Services;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Users.Commands.Delete;

public class DeleteUserCommand : IRequest<DeleteUserResponse>
{
    public Guid Id { get; set; }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        public DeleteUserCommandHandler(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        public async Task<DeleteUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            User user = await userService.GetAsync(u => u.Id == request.Id, cancellationToken: cancellationToken);

            User result = await userService.DeleteAsync(user);

            DeleteUserResponse response = mapper.Map<DeleteUserResponse>(result);

            return response;
        }
    }
}
