namespace HelpDesk.Domain.Entities;

public class TicketComment
{
    public Guid Id { get; set; }

    public Guid TicketId { get; set; }

    public Guid AuthorUserId { get; set; }

    public string Message { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}
