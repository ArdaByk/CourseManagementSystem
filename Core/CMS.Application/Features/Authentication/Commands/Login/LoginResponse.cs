using System;

namespace CMS.Application.Features.Authentication.Commands.Login;

public class LoginResponse
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public string? Token { get; set; }
    public Guid? UserId { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? FullName { get; set; }
    public Guid? RoleId { get; set; }
    public string? RoleName { get; set; }
}

