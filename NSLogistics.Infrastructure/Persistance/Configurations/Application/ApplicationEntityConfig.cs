using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NSLogistics.Core.Application;

namespace NSLogistics.Infrastructure.Persistance.Configurations.Application;

internal class ApplicationEntityConfig
    : IEntityTypeConfiguration<ApplicationEntity>
{
    public void Configure(EntityTypeBuilder<ApplicationEntity> builder)
    {
        builder.ToTable("applications");

        builder.HasKey(a => a.ApplicationId);

        builder
            .Property(a => a.ApplicationId)
            .ValueGeneratedOnAdd();

        builder
            .Property(a => a.CarBrand)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(a => a.CarModel)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(a => a.CarYear)
            .HasMaxLength(4)
            .IsRequired();

        builder
            .Property(a => a.AuctionName)
            .HasMaxLength(100);

        builder
            .Property(a => a.VinCode)
            .HasMaxLength(17)
            .IsRequired();

        builder
            .Property(a => a.PurchaseDate)
            .IsRequired();

        builder
            .Property(a => a.ContainerNumber)
            .HasMaxLength(50);

        builder
            .Property(a => a.ShipmentName)
            .HasMaxLength(100);

        builder
            .Property(a => a.AuctionPrice)
            .HasColumnType("decimal(18, 2)");

        builder
            .Property(a => a.ShipmentPrice)
            .HasColumnType("decimal(18, 2)");

        builder
            .Property(a => a.ArrivalDate);

        builder
            .Property(a => a.OpeningDate);

        // Relationships
        builder
            .HasOne(a => a.User)
            .WithMany(u => u.Applications)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasMany(a => a.CarImages)
            .WithOne(i => i.Application)
            .HasForeignKey(i => i.ApplicationId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
