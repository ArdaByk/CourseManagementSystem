using CMS.Application.Common.Authentication;
using CMS.Application.Common.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Application.CrossCuttingConcerns.Authorization;

public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var authorizeAttribute = typeof(TRequest).GetCustomAttribute<AuthorizeAttribute>();

        if (authorizeAttribute != null)
        {
            var currentUser = CurrentUserContext.Instance;

            if (!currentUser.IsAuthenticated)
            {
                throw new UnauthorizedAccessException("Giriş yapmanız gerekiyor.");
            }

            var userRole = currentUser.RoleName ?? string.Empty;

            if (userRole == RoleConstants.Admin)
            {
                return await next();
            }

            if (authorizeAttribute.AllowedRoles.Any() && !authorizeAttribute.AllowedRoles.Contains(userRole))
            {
                throw new UnauthorizedAccessException($"Bu işlem için yetkiniz bulunmamaktadır. Gerekli roller: {string.Join(", ", authorizeAttribute.AllowedRoles)}");
            }
        }

        return await next();
    }
}

