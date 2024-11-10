using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NSLogistics.Core.Shipping;

namespace NSLogistics.Infrastructure.Persistance.Configurations.Shipping;

internal class ShippingPriceEntityConfig
    : IEntityTypeConfiguration<ShippingPriceEntity>
{
    public void Configure(EntityTypeBuilder<ShippingPriceEntity> builder)
    {
        builder.ToTable("shipping_prices");

        builder.HasKey(sp => sp.ShippingPriceId);

        builder
            .Property(sp => sp.ShippingPriceId)
            .ValueGeneratedOnAdd();

        builder
            .Property(sp => sp.Price)
            .HasColumnType("decimal(18, 2)")
            .IsRequired();

        builder
            .Property(sp => sp.TransitDays);

        builder
            .HasOne<LocationEntity>()
            .WithMany()
            .HasForeignKey(sp => sp.OriginLocationId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne<LocationEntity>()
            .WithMany()
            .HasForeignKey(sp => sp.DestinationLocationId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}

