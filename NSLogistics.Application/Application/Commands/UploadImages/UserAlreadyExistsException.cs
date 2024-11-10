using NSLogistics.Application.Common.Exceptions;

namespace NSLogistics.Application.Application.Commands.UploadImages;

public class ApplicationNotFoundException : BaseException
{
    public ApplicationNotFoundException(string message)
        : base(message) { }
}
