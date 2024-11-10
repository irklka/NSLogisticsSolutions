using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using NSLogistics.Core.Application;
using NSLogistics.Core.Shipping;
using NSLogistics.Core.User;

namespace NSLogistics.Infrastructure.Persistance;

public class AppDbContext : DbContext
{
    public IConfiguration Configuration { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options,
        IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ApplicationEntity> Applications { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<LocationEntity> Locations { get; set; }
    public DbSet<ShippingPriceEntity> ShippingPrices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.EnableDetailedErrors();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<UserEntity>().HasData(
            new UserEntity
            {
                Id = Guid.NewGuid(),
                Firstname = "Saba",
                Lastname = "Sani-Peradze",
                IdNumber = "00000000001",
                DateOfBirth = new DateTime(2000, 1, 1),
                Email = "saba.peradze@example.com",
                Password = "C62D1C801386EDBDB84735BA14E873B007AF19841A5EC0BE22AD34478FD33086",// tormetii
                Salt = "qzlxcBpNh8pJq5GP1V7OBA=="
            }
        );

        base.OnModelCreating(modelBuilder);
    }
}
