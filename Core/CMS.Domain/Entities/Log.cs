using CMS.Domain.Common;

namespace CMS.Domain.Entities;

public class Log : BaseEntity<Guid>
{
    public string Level { get; set; } = null!;
    public string RequestName { get; set; } = null!;
    public string Message { get; set; } = null!;

    public string? UserId { get; set; }
    public string? Username { get; set; }

    public string? Payload { get; set; }
    public double? ElapsedMilliseconds { get; set; }

    public string? ExceptionMessage { get; set; }
    public string? ExceptionStackTrace { get; set; }
}


