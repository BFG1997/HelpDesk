using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(Guid userId, string message, CancellationToken cancellationToken);
    }
}
