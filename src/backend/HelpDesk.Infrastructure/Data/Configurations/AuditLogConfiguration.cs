using HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infrastructure.Data.Configurations;

public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.EntityType)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.EntityId)
            .IsRequired();

        builder.Property(a => a.Action)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(a => a.At)
            .IsRequired();

        // Для DetailsJson оставляем стандартное поведение EF Core
        // В PostgreSQL это будет тип text, что достаточно
        builder.Property(a => a.DetailsJson);

        builder.HasOne(a => a.WhoUser)
            .WithMany()
            .HasForeignKey(a => a.WhoUserId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
