using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Security.Hashing;
using CMS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Users.Queries.Login;

public class LoginQuery : IRequest<LoginResponse>
{
    public string? EmailOrUsername { get; set; }
    public string? Password { get; set; }
}

public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResponse>
{
    private readonly IUserService userService;

    public LoginQueryHandler(IUserService userService)
    {
        this.userService = userService;
    }

    public async Task<LoginResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
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

        return new LoginResponse
        {
            Success = true,
            Message = "Giriş başarılı.",
            UserId = user.Id,
            Username = user.Username,
            Email = user.Email,
            FullName = user.FullName,
            RoleId = user.RoleId,
            RoleName = user.Role?.RoleName
        };
    }
}

