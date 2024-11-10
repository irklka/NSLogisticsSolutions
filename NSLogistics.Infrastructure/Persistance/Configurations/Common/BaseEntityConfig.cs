using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NSLogistics.Core.Common;

namespace NSLogistics.Infrastructure.Persistance.Configurations.Common;

internal abstract class BaseEntityConfig<TEntity>
    : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntity
{
    public virtual void Configure(
        EntityTypeBuilder<TEntity> builder)
    {
        builder
            .HasQueryFilter(e => !e.IsDeleted);

        builder
            .Property(x => x.CreatedById)
            .IsRequired();

        builder
            .Property(x => x.CreatedDateTime)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();
    }
}
