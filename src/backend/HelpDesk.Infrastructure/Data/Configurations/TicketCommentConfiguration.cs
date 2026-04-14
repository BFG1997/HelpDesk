using HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infrastructure.Data.Configurations;

public class TicketCommentConfiguration : IEntityTypeConfiguration<TicketComment>
{
    public void Configure(EntityTypeBuilder<TicketComment> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Message)
            .IsRequired()
            .HasMaxLength(2000);

        builder.Property(c => c.CreatedAt)
            .IsRequired();

        // Связь с Ticket: многие к одному
        builder.HasOne(c => c.Ticket)
            .WithMany()                     
            .HasForeignKey(c => c.TicketId)
            .OnDelete(DeleteBehavior.Cascade); 

        // Связь с Author (User)
        builder.HasOne(c => c.AuthorUser)
            .WithMany()
            .HasForeignKey(c => c.AuthorUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
