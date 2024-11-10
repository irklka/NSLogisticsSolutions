using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NSLogistics.Core.Application;

namespace NSLogistics.Infrastructure.Persistance.Configurations.Application;

internal class ImageConfig
    : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.ToTable("images");

        builder.HasKey(i => i.ImageId);

        builder
            .Property(i => i.ImageId)
            .ValueGeneratedOnAdd();

        builder
            .Property(i => i.ImageOrigin)
            .IsRequired();

        builder
            .Property(i => i.ImageBytes)
            .IsRequired();

        builder
            .Property(i => i.ImageType)
            .HasMaxLength(10);

        builder
            .HasOne(i => i.Application)
            .WithMany(a => a.CarImages)
            .HasForeignKey(i => i.ImageId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
