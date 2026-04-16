using HelpDesk.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;

namespace HelpDesk.Application.Common.Interfaces
{
    public interface IApplicationDbContext : IUnitOfWork
    {
        DbSet<User> Users { get; }
        DbSet<Ticket> Tickets { get; }
        DbSet<TicketComment> TicketComments { get; }
        DbSet<Domain.Entities.Attachment> Attachments { get; }
        DbSet<Category> Categories { get; }
        DbSet<AuditLog> AuditLogs { get; }
        DbSet<Notification> Notifications { get; }
    }
}
