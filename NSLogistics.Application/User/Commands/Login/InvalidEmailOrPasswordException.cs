using NSLogistics.Application.Common.Exceptions;

namespace NSLogistics.Application.User.Commands.Login;

public class InvalidEmailOrPasswordException : BaseException
{
    public InvalidEmailOrPasswordException(string message) : base(message) { }
}
