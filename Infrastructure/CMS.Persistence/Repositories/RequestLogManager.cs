using CMS.Application.Abstractions.Services;
using CMS.Domain.Entities;
using CMS.Persistence.Common.Repositories;
using CMS.Persistence.Contexts;

namespace CMS.Persistence.Repositories;

public class RequestLogManager : BaseRepository<Log, Guid, CMSDbContext>, IRequestLogService
{
    public RequestLogManager(CMSDbContext context) : base(context)
    {
    }

    public async Task LogAsync(Log log, CancellationToken cancellationToken = default)
    {
        await AddAsync(log);
    }
}


