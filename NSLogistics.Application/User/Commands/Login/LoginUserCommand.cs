using FluentValidation;

using MediatR;

namespace NSLogistics.Application.User.Commands.Login;

public record LoginUserCommand : IRequest<LoginUserCommandResponse>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

}

public class LoginUserCommandValidator
    : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty();
        RuleFor(x => x.Password)
            .NotEmpty();
    }
}
