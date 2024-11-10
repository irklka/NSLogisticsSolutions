using System.Security.Claims;

using Microsoft.AspNetCore.Http;

using NSLogistics.Application.Common.Services.User.Interfaces;

using static NSLogistics.Core.User.Enums.Roles;

namespace NSLogistics.Application.Common.Services.User;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public bool IsAdmin()
    {
        var roleClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Role);
        return roleClaim != null && AdminUsers.Contains(roleClaim.Value);
    }
}
