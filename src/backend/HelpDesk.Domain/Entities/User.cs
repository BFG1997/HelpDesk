using HelpDesk.Domain.Enums;

namespace HelpDesk.Domain.Entities;

public class User
{
    public Guid Id { get; set; }

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public UserRole Role { get; set; }

    public string DisplayName { get; set; } = string.Empty;
}
