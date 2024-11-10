using NSLogistics.Application.Common.Exceptions;

namespace NSLogistics.Application.User.Commands.Register;

public class UserAlreadyExistsException : BaseException
{
    public UserAlreadyExistsException(string message)
        : base(message) { }
}
