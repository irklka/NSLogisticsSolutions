namespace NSLogistics.Application.User.Commands.Register;

public record RegisterUserCommandResponse(User User);

public record User(Guid UserId, string Fullname);
