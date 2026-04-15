using HelpDesk.Application.Common.Interfaces;
using HelpDesk.Domain.Entities;

namespace HelpDesk.Infrastructure.Services;

public class NotificationService : INotificationService
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IDateTime _dateTime;

    public NotificationService(IApplicationDbContext applicationDbContext, IDateTime dateTime)
    {
        _applicationDbContext = applicationDbContext;
        _dateTime = dateTime;
    }

    public async Task SendAsync(Guid userId, string message, CancellationToken cancellationToken)
    {
        var notification = new Notification()
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Message = message,
            CreatedAt = _dateTime.UtcNow,
            IsRead = false
        };

        _applicationDbContext.Notifications.Add(notification);

        await _applicationDbContext.SaveChangesAsync(cancellationToken);
    }
}
