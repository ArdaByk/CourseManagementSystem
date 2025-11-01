using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Authentication;
using System;
using System.Threading.Tasks;

namespace CMS.Application.Common.Authorization;

public static class AuthorizationHelper
{
    public static async Task<Guid?> GetTeacherIdFromCurrentUserAsync(ITeacherService teacherService)
    {
        var currentUser = CurrentUserContext.Instance;
        
        if (currentUser.RoleName != RoleConstants.Teacher || string.IsNullOrEmpty(currentUser.Email))
        {
            return null;
        }

        var teacher = await teacherService.GetAsync(
            predicate: t => t.Email == currentUser.Email,
            enableTracking: false
        );

        return teacher?.Id;
    }
}

