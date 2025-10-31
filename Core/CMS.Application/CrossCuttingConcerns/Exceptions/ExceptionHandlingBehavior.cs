using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using CMS.Application.Abstractions.Notifications;

namespace CMS.Application.CrossCuttingConcerns.Exceptions;

public class ExceptionHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<ExceptionHandlingBehavior<TRequest, TResponse>> _logger;
    private readonly IUserNotification? _userNotification;

    public ExceptionHandlingBehavior(ILogger<ExceptionHandlingBehavior<TRequest, TResponse>> logger, IUserNotification? userNotification = null)
    {
        _logger = logger;
        _userNotification = userNotification;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (ValidationException vex)
        {
            _logger.LogWarning(vex, "Validation failed for {RequestName}", typeof(TRequest).Name);
            throw;
        }
        catch (OperationCanceledException)
        {
            _logger.LogWarning("Request {RequestName} was cancelled", typeof(TRequest).Name);
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception for request {RequestName} with payload {@Request}", typeof(TRequest).Name, request);
            
            _userNotification?.ShowError("Beklenmeyen Hata", ex.Message);
            throw;
        }
    }
}


