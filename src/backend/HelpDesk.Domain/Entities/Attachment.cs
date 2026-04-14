namespace HelpDesk.Domain.Entities;

public class Attachment
{
    public Guid Id { get; set; }

    public Guid TicketId { get; set; }
    public Ticket Ticket { get; set; } = null!;

    public Guid UploadedByUserId { get; set; }
    public User UploadedByUser { get; set; } = null!;

    public string FileName { get; set; } = string.Empty;

    public string ContentType { get; set; } = string.Empty;

    public long Size { get; set; }

    public string StoragePath { get; set; } = string.Empty;

    public DateTime UploadedAt { get; set; }
}
