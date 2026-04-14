using HelpDesk.Application.Common.Interfaces;
using HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HelpDesk.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<User> Users => Set<User>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<TicketComment> TicketComments => Set<TicketComment>();
        public DbSet<Attachment> Attachments => Set<Attachment>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
        public DbSet<Notification> Notifications => Set<Notification>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
