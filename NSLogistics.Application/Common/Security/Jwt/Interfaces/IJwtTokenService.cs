using static NSLogistics.Core.User.Enums.Roles;

namespace NSLogistics.Application.Common.Security.Jwt.Interfaces;

public interface IJwtTokenService
{
    Task<string> GenerateTokenAsync(
        Guid userId,
        UserRole role);
}
