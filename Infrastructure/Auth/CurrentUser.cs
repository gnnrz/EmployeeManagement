using Application.Common.Interfaces;
using Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Infrastructure.Auth;

public class CurrentUser : ICurrentUser
{
    public Guid Id { get; }
    public string Email { get; } = string.Empty;
    public Role Role { get; }
    public bool IsAuthenticated { get; }

    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        var user = httpContextAccessor.HttpContext?.User;

        IsAuthenticated = user?.Identity?.IsAuthenticated == true;

        if (!IsAuthenticated)
            return;

        var userId = user!.FindFirst(ClaimTypes.NameIdentifier)
                     ?? user.FindFirst(JwtRegisteredClaimNames.Sub);

        if (userId is not null)
            Id = Guid.Parse(userId.Value);

        Email = user.FindFirst(ClaimTypes.Email)?.Value ?? string.Empty;

        var role = user.FindFirst(ClaimTypes.Role)?.Value;
        if (role is not null)
            Role = Enum.Parse<Role>(role);
    }
}
