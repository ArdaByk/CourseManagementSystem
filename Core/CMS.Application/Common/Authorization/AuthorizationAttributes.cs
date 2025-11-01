namespace CMS.Application.Common.Authorization;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class AuthorizeAttribute : Attribute
{
    public string[] AllowedRoles { get; }
    
    public AuthorizeAttribute(params string[] allowedRoles)
    {
        AllowedRoles = allowedRoles;
    }
}

