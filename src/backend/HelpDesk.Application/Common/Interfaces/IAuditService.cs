using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Application.Common.Interfaces
{
    public interface IAuditService
    {
        /// <param name="entityType">Имя сущности, например "Ticket"</param>
        /// <param name="entityId">Id сущности</param>
        /// <param name="action">Действие: Created, Updated, Deleted, StatusChanged и т.п.</param>
        /// <param name="whoUserId">Id пользователя, совершившего действие</param>
        /// <param name="details">Дополнительные данные в виде объекта (будут сериализованы в JSON)</param>
        Task LogAsync(string entityType, Guid entityId, string action, Guid? whoUserId, object? details = null);
    }
}
