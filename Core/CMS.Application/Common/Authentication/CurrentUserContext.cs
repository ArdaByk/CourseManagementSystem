using System;

namespace CMS.Application.Common.Authentication;

public class CurrentUserContext
{
    private static CurrentUserContext _instance;
    private static readonly object _lock = new object();

    private CurrentUserContext() { }

    public static CurrentUserContext Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new CurrentUserContext();
                    }
                }
            }
            return _instance;
        }
    }

    public string? Token { get; private set; }
    public Guid? UserId { get; private set; }
    public string? Username { get; private set; }
    public string? Email { get; private set; }
    public string? FullName { get; private set; }
    public Guid? RoleId { get; private set; }
    public string? RoleName { get; private set; }
    public bool IsAuthenticated => !string.IsNullOrEmpty(Token) && UserId.HasValue;

    public void SetUser(string token, Guid userId, string? username, string? email, string? fullName, Guid roleId, string? roleName)
    {
        Token = token;
        UserId = userId;
        Username = username;
        Email = email;
        FullName = fullName;
        RoleId = roleId;
        RoleName = roleName;
    }

    public void Clear()
    {
        Token = null;
        UserId = null;
        Username = null;
        Email = null;
        FullName = null;
        RoleId = null;
        RoleName = null;
    }
}

