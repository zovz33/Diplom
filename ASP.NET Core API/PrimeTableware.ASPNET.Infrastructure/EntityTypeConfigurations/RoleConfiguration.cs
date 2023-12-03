﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PrimeTableware.ASPNET.Domain.Entities.Identity;

namespace PrimeTableware.ASPNET.Infrastructure.EntityTypeConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey("Id");
            builder.HasIndex("Id").IsUnique();
            //builder.HasIndex("Name").IsUnique();
            builder.Property(u => u.Name).HasMaxLength(20).IsRequired();
            builder.Property(u => u.Description).HasMaxLength(256);

            builder.Property("CreatedBy").HasMaxLength(20);
            builder.Property("CreatedDateTime").IsRequired();
            builder.Property("LastUpdatedBy").HasMaxLength(20);
            builder.Property("UpdatedDateTime");

            builder.HasMany(e => e.UserRoles)
                .WithOne(e => e.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            builder.HasMany(e => e.RoleClaims)
                .WithOne(e => e.Role)
                .HasForeignKey(rc => rc.RoleId)
                .IsRequired();
        }
    }
}
