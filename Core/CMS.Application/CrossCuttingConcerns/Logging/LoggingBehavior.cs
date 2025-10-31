using MediatR;
using Microsoft.Extensions.Logging;

namespace CMS.Application.CrossCuttingConcerns.Logging;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        _logger.LogInformation("Handling {RequestName} with payload {@Request}", requestName, request);

        var start = DateTime.UtcNow;
        try
        {
            var response = await next();
            var elapsedMs = (DateTime.UtcNow - start).TotalMilliseconds;
            _logger.LogInformation("Handled {RequestName} in {Elapsed} ms", requestName, elapsedMs);
            return response;
        }
        catch
        {
            var elapsedMs = (DateTime.UtcNow - start).TotalMilliseconds;
            _logger.LogWarning("{RequestName} failed after {Elapsed} ms", requestName, elapsedMs);
            throw;
        }
    }
}


