namespace HelpDesk.Domain.Entities;

public class Attachment
{
    public Guid Id { get; set; }

    public Guid TicketId { get; set; }

    public Guid UploadedByUserId { get; set; }

    public string FileName { get; set; } = string.Empty;

    public string ContentType { get; set; } = string.Empty;

    public long Size { get; set; }

    public string StoragePath { get; set; } = string.Empty;

    public DateTime UploadedAt { get; set; }
}
