using HelpDesk.Application.Common.Interfaces;
using HelpDesk.Domain.Entities;
using System.Text.Json;

namespace HelpDesk.Infrastructure.Services;

public class AuditService : IAuditService
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IDateTime _dateTime;

    public AuditService(IApplicationDbContext applicationDbContext, IDateTime dateTime)
    {
        _applicationDbContext = applicationDbContext;
        _dateTime = dateTime;
    }

    public async Task LogAsync(string entityType, Guid entityId, string action, Guid? whoUserId, object? details = null, CancellationToken cancellationToken = default)
    {
        var auditLog = new AuditLog()
        {
            Id = Guid.NewGuid(),
            EntityId = entityId,
            WhoUserId = whoUserId,
            EntityType = entityType,
            Action = action,
            At = _dateTime.UtcNow,
            DetailsJson = details != null ? JsonSerializer.Serialize(details) : null
        };

        _applicationDbContext.AuditLogs.Add(auditLog);

        await _applicationDbContext.SaveChangesAsync(cancellationToken);
    }
}
