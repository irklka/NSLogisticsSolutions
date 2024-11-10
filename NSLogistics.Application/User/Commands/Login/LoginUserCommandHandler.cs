using Ardalis.Specification;

using MediatR;

using NSLogistics.Application.Common.Security.Jwt.Interfaces;
using NSLogistics.Application.Common.Security.Password;
using NSLogistics.Core.User;
using NSLogistics.Core.User.Specifications;

namespace NSLogistics.Application.User.Commands.Login;

public class LoginUserCommandHandler
    : IRequestHandler<LoginUserCommand, LoginUserCommandResponse>
{
    private readonly IReadRepositoryBase<UserEntity> _userReadRepository;
    private readonly IJwtTokenService _tokenService;

    public LoginUserCommandHandler(IReadRepositoryBase<UserEntity> userReadRepository,
        IJwtTokenService tokenService)
    {
        _userReadRepository = userReadRepository;
        _tokenService = tokenService;
    }

    public async Task<LoginUserCommandResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userReadRepository.SingleOrDefaultAsync(
            new GetUserByEmailSpec(request.Email),
            cancellationToken);

        if (user is null || !PasswordManager.IsValidPassword(request.Password, user.Password, user.Salt))
        {
            throw new InvalidEmailOrPasswordException($"invalid email and password combination ({request.Email})");
        }

        var token = await _tokenService.GenerateTokenAsync(user.Id, user.Role);

        return new LoginUserCommandResponse(
            new(user.Id, $"{user.Firstname} {user.Lastname}"),
            token,
            user.Role.ToString());
    }
}
