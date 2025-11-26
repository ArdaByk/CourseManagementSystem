using System.Text.Json;
using CMS.Application.Abstractions.Services;
using CMS.Application.Common.Authentication;
using CMS.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CMS.Application.CrossCuttingConcerns.Logging;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
    private readonly IRequestLogService _requestLogService;

    public LoggingBehavior(
        ILogger<LoggingBehavior<TRequest, TResponse>> logger,
        IRequestLogService requestLogService)
    {
        _logger = logger;
        _requestLogService = requestLogService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var payload = JsonSerializer.Serialize(request);

        var currentUser = CurrentUserContext.Instance;
        var userId = currentUser.UserId?.ToString();
        var username = currentUser.Username;

        _logger.LogInformation("Handling {RequestName} with payload {@Request}", requestName, request);

        await TryLogToDatabaseAsync(new Log
        {
            Level = "Information",
            RequestName = requestName,
            Message = $"Handling {requestName}",
            UserId = userId,
            Username = username,
            Payload = payload
        }, cancellationToken);

        var start = DateTime.UtcNow;
        try
        {
            var response = await next();
            var elapsedMs = (DateTime.UtcNow - start).TotalMilliseconds;
            _logger.LogInformation("Handled {RequestName} in {Elapsed} ms", requestName, elapsedMs);

            await TryLogToDatabaseAsync(new Log
            {
                Level = "Information",
                RequestName = requestName,
                Message = $"Handled {requestName} in {elapsedMs} ms",
                UserId = userId,
                Username = username,
                Payload = payload,
                ElapsedMilliseconds = elapsedMs
            }, cancellationToken);

            return response;
        }
        catch (Exception ex)
        {
            var elapsedMs = (DateTime.UtcNow - start).TotalMilliseconds;
            _logger.LogWarning(ex, "{RequestName} failed after {Elapsed} ms", requestName, elapsedMs);

            await TryLogToDatabaseAsync(new Log
            {
                Level = "Error",
                RequestName = requestName,
                Message = $"Request {requestName} failed: {ex.Message}",
                UserId = userId,
                Username = username,
                Payload = payload,
                ElapsedMilliseconds = elapsedMs,
                ExceptionMessage = ex.Message,
                ExceptionStackTrace = ex.StackTrace
            }, cancellationToken);

            throw;
        }
    }

    private async Task TryLogToDatabaseAsync(Log log, CancellationToken cancellationToken)
    {
        try
        {
            await _requestLogService.LogAsync(log, cancellationToken);
        }
        catch
        {
            throw new Exception("Logging to database failed");
        }
    }
}


