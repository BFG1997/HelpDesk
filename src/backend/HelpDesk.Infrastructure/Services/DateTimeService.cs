using HelpDesk.Application.Common.Interfaces;

namespace HelpDesk.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime UtcNow => DateTime.UtcNow;
}
