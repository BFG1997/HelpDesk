namespace HelpDesk.Domain.Entities;

public class AuditLog
{
    public Guid Id { get; set; }

    public string EntityType { get; set; } = string.Empty;

    public string EntityId { get; set; } = string.Empty;

    public string Action { get; set; } = string.Empty;

    public Guid WhoUserId { get; set; }

    public DateTime At { get; set; }

    public string DetailsJson { get; set; } = string.Empty;
}
