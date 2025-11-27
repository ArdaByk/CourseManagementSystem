using System.Text.Json;
using CMS.Application.Abstractions.Notifications;
using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Authentication;
using CMS.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CMS.Application.CrossCuttingConcerns.Exceptions;

public class ExceptionHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<ExceptionHandlingBehavior<TRequest, TResponse>> _logger;
    private readonly IUserNotification? _userNotification;
    private readonly IRequestLogService? _requestLogService;

    public ExceptionHandlingBehavior(
        ILogger<ExceptionHandlingBehavior<TRequest, TResponse>> logger,
        IUserNotification? userNotification = null,
        IRequestLogService? requestLogService = null)
    {
        _logger = logger;
        _userNotification = userNotification;
        _requestLogService = requestLogService;
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
            await TryLogValidationExceptionAsync(request, vex, cancellationToken);
            throw;
        }
        catch (OperationCanceledException)
        {
            _logger.LogWarning("Request {RequestName} was cancelled", typeof(TRequest).Name);
            await TryLogCanceledAsync(request, cancellationToken);
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception for request {RequestName} with payload {@Request}", typeof(TRequest).Name, request);
            await TryLogUnhandledExceptionAsync(request, ex, cancellationToken);
            
            _userNotification?.ShowError("Beklenmeyen Hata", ex.Message);
            throw;
        }
    }

    private async Task TryLogValidationExceptionAsync(TRequest request, ValidationException exception, CancellationToken cancellationToken)
    {
        if (_requestLogService is null) return;

        try
        {
            var currentUser = CurrentUserContext.Instance;
            var payload = JsonSerializer.Serialize(request);

            var log = new Log
            {
                Level = "Warning",
                RequestName = typeof(TRequest).Name,
                Message = $"Validation failed: {exception.Message}",
                UserId = currentUser.UserId?.ToString(),
                Username = currentUser.Username,
                Payload = payload,
                ExceptionMessage = exception.Message,
                ExceptionStackTrace = exception.StackTrace
            };

            await _requestLogService.LogAsync(log, cancellationToken);
        }
        catch
        {
        }
    }

    private async Task TryLogCanceledAsync(TRequest request, CancellationToken cancellationToken)
    {
        if (_requestLogService is null) return;

        try
        {
            var currentUser = CurrentUserContext.Instance;
            var payload = JsonSerializer.Serialize(request);

            var log = new Log
            {
                Level = "Information",
                RequestName = typeof(TRequest).Name,
                Message = "Request was cancelled",
                UserId = currentUser.UserId?.ToString(),
                Username = currentUser.Username,
                Payload = payload
            };

            await _requestLogService.LogAsync(log, cancellationToken);
        }
        catch
        {
        }
    }

    private async Task TryLogUnhandledExceptionAsync(TRequest request, Exception exception, CancellationToken cancellationToken)
    {
        if (_requestLogService is null) return;

        try
        {
            var currentUser = CurrentUserContext.Instance;
            var payload = JsonSerializer.Serialize(request);

            var log = new Log
            {
                Level = "Error",
                RequestName = typeof(TRequest).Name,
                Message = $"Unhandled exception: {exception.Message}",
                UserId = currentUser.UserId?.ToString(),
                Username = currentUser.Username,
                Payload = payload,
                ExceptionMessage = exception.Message,
                ExceptionStackTrace = exception.StackTrace
            };

            await _requestLogService.LogAsync(log, cancellationToken);
        }
        catch
        {
        }
    }
}


