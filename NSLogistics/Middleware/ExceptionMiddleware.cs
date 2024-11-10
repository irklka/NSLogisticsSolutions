using System.Net;
using System.Text.Json;

using NSLogistics.Application.Application.Commands.UploadImages;
using NSLogistics.Application.Common.Exceptions;
using NSLogistics.Application.User.Commands.Login;
using NSLogistics.Application.User.Commands.Register;

namespace NSLogistics.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next,
        ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var exceptionTypeToStatusCode = new Dictionary<Type, HttpStatusCode>
    {
        { typeof(ValidationException), HttpStatusCode.BadRequest },
        { typeof(InvalidEmailOrPasswordException), HttpStatusCode.BadRequest },
        { typeof(UserAlreadyExistsException), HttpStatusCode.BadRequest },
        { typeof(UnauthorizedAccessException), HttpStatusCode.Unauthorized },
        { typeof(ApplicationNotFoundException), HttpStatusCode.NotFound }
        // Add additional mappings here as needed
    };

        var statusCode = exceptionTypeToStatusCode.TryGetValue(exception.GetType(), out var code)
            ? code
            : HttpStatusCode.InternalServerError;

        var message = statusCode == HttpStatusCode.InternalServerError
            ? "Internal error, try again later"
            : exception.Message;

        if (exception is ValidationException exception1)
        {
            message = string.Join(", ", exception1.Errors);
        }

        LogError(message, statusCode);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;
        await context.Response.WriteAsync(JsonSerializer.Serialize(new { error = message }));
    }

    private void LogError(string message, HttpStatusCode statusCode)
        => _logger.LogError("Exception was thrown [StatusCode: {0}]: {1}", statusCode, message);
}
