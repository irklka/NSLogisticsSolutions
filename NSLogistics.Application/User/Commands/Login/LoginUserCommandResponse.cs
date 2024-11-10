namespace NSLogistics.Application.User.Commands.Login;

public record LoginUserCommandResponse(User User, string Token, string Role);

public record User(Guid UserId, string Fullname);
