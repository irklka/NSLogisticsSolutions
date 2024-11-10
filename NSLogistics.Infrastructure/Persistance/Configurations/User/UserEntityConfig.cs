﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NSLogistics.Core.User;
using NSLogistics.Infrastructure.Persistance.Configurations.Common;

namespace NSLogistics.Infrastructure.Persistance.Configurations.User;

internal class UserEntityConfig
    : BaseEntityConfig<UserEntity>
{
    public override void Configure(
        EntityTypeBuilder<UserEntity> builder)
    {
        base.Configure(builder);

        builder.ToTable("users");

        builder
            .Property(u => u.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(u => u.Firstname)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(u => u.Lastname)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(u => u.IdNumber)
            .IsRequired()
            .HasMaxLength(11)
            .IsFixedLength(true);

        builder
            .Property(u => u.DateOfBirth)
            .IsRequired();

        builder
            .Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(70);

        builder
            .Property(u => u.Salt)
            .IsRequired()
            .HasMaxLength(30);

        builder
            .Property(u => u.Role)
            .IsRequired();

        builder
            .HasMany(x => x.Applications)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
