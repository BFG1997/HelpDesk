using HelpDesk.Application.Common.Interfaces;
using HelpDesk.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace HelpDesk.Infrastructure.Services;

public class CurrentUserService : ICurrentUserService
{
    private IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid UserId 
    {
        get
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ??
                         _httpContextAccessor.HttpContext?.User?.FindFirst("sub")?.Value;

            return userId != null ? Guid.Parse(userId) : Guid.Empty;
        }
    }

    public string Email => _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value ?? string.Empty;

    public UserRole Role
    {
        get
        {
            var roleClaim = _httpContextAccessor.HttpContext?.User?.FindFirst("role")?.Value;

            return Enum.TryParse<UserRole>(roleClaim, out var role) ? role : UserRole.Client;
        }
    }

    public bool IsAuthenticated => _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
}
