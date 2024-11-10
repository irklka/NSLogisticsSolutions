using Ardalis.Specification;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using NSLogistics.Infrastructure.Persistance;
using NSLogistics.Infrastructure.Persistance.Repositories;

namespace NSLogistics.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("AppDbConnection"));
        });

        services.AddScoped(typeof(IRepositoryBase<>), typeof(EfRepository<>));
        services.AddScoped(typeof(IReadRepositoryBase<>), typeof(EfRepository<>));

        return services;
    }
}
