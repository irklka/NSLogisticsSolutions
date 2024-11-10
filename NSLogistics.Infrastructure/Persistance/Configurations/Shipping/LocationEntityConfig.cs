using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NSLogistics.Core.Shipping;

namespace NSLogistics.Infrastructure.Persistance.Configurations.Shipping;

internal class LocationEntityConfig
    : IEntityTypeConfiguration<LocationEntity>
{
    public void Configure(EntityTypeBuilder<LocationEntity> builder)
    {
        builder.ToTable("locations");

        builder.HasKey(l => l.LocationId);

        builder
            .Property(l => l.LocationId)
            .ValueGeneratedOnAdd();

        builder
            .Property(l => l.LocationName)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(l => l.Country)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(l => l.PortCode)
            .HasMaxLength(10)
            .IsRequired();
    }
}
