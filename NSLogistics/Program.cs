using NSLogistics.Api;
using NSLogistics.Api.Middleware;
using NSLogistics.Application;
using NSLogistics.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.UseCors("AllowFrontend");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();

app.UseMiddleware<RequestDiagnosticsMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();



public class RequestDiagnosticsMiddleware
{
    private readonly RequestDelegate _next;

    public RequestDiagnosticsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // I don't yet called Controller/Action.
        //log the essential parts of the request here

        // Call the next delegate/middleware in the pipeline
        await _next(context);
    }
}
