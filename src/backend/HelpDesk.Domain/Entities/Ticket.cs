using HelpDesk.Domain.Enums;

namespace HelpDesk.Domain.Entities;

public class Ticket
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public TicketStatus Status { get; set; }

    public TicketPriority Priority { get; set; }

    public Guid CreatedByUserId { get; set; }
    public User CreatedByUser { get; set; } = null!;

    public Guid? AssignedToUserId { get; set; }
    public User AssignedToUser { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? ClosedAt { get; set; }
}
