using HelpDesk.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HelpDesk.Application.Features.Auth.DTOs
{
    public class AuthResponse
    {
        public Guid UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UserRole Role { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}
