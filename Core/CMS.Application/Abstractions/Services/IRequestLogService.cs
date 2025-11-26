using CMS.Domain.Entities;

namespace CMS.Application.Abstractions.Services;

public interface IRequestLogService
{
    Task LogAsync(Log log, CancellationToken cancellationToken = default);
}


