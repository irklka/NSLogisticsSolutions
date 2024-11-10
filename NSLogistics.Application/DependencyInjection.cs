using System.Reflection;

using FluentValidation;

using MediatR;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using NSLogistics.Application.Common.Behaviours;
using NSLogistics.Application.Common.Security.Jwt;
using NSLogistics.Application.Common.Security.Jwt.Interfaces;
using NSLogistics.Application.Common.Security.Jwt.Options;
using NSLogistics.Application.Common.Services.User;
using NSLogistics.Application.Common.Services.User.Interfaces;

namespace NSLogistics.Application;

public static class DependencyInjection
{
    public static void AddApplicationServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddHttpContextAccessor();

        services.Configure<JwtTokenOptions>(options =>
               configuration.GetSection(JwtTokenOptions.Key).Bind(options));

        services.AddScoped<IJwtTokenService, JwtTokenService>();
    }
}
