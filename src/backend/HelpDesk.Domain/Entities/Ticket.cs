using HelpDesk.Domain.Enums;

namespace HelpDesk.Domain.Entities;

public class Ticket
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Guid CategoryId { get; set; }

    public TicketStatus Status { get; set; }

    public TicketPriority Priority { get; set; }

    public Guid CreatedByUserId { get; set; }

    public Guid? AssignedToUserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? ClosedAt { get; set; }
}
