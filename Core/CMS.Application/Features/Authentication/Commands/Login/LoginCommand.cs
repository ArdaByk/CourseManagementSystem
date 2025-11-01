using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Security.Hashing;
using CMS.Application.Common.Security.Jwt;
using CMS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Authentication.Commands.Login;

public class LoginCommand : IRequest<LoginResponse>
{
    public string? EmailOrUsername { get; set; }
    public string? Password { get; set; }
}

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IUserService userService;
    private readonly ITokenService tokenService;

    public LoginCommandHandler(IUserService userService, ITokenService tokenService)
    {
        this.userService = userService;
        this.tokenService = tokenService;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.EmailOrUsername) || string.IsNullOrWhiteSpace(request.Password))
        {
            return new LoginResponse
            {
                Success = false,
                Message = "E-posta/kullanıcı adı ve şifre boş olamaz."
            };
        }

        User? user = await userService.GetAsync(
            predicate: u => u.Email == request.EmailOrUsername || u.Username == request.EmailOrUsername,
            include: u => u.Include(u => u.Role),
            enableTracking: false,
            cancellationToken: cancellationToken
        );

        if (user == null)
        {
            return new LoginResponse
            {
                Success = false,
                Message = "E-posta veya kullanıcı adı bulunamadı."
            };
        }

        bool isPasswordValid = HashingHelper.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt);

        if (!isPasswordValid)
        {
            return new LoginResponse
            {
                Success = false,
                Message = "Şifre hatalı."
            };
        }

        string token = tokenService.GenerateToken(user);

        return new LoginResponse
        {
            Success = true,
            Message = "Giriş başarılı.",
            Token = token,
            UserId = user.Id,
            Username = user.Username,
            Email = user.Email,
            FullName = user.FullName,
            RoleId = user.RoleId,
            RoleName = user.Role?.RoleName
        };
    }
}

