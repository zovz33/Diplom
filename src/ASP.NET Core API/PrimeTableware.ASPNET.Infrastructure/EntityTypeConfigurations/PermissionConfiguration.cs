﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PrimeTableware.ASPNET.Domain.Entities;
using System;


namespace PrimeTableware.ASPNET.Infrastructure.EntityTypeConfigurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {

        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(user => user.Id);
            builder.HasIndex(user => user.Id).IsUnique();


            builder.Property(user => user.CreatedBy).HasMaxLength(20);
            builder.Property(user => user.CreatedDateTime).IsRequired();
            builder.Property(user => user.LastUpdatedBy).HasMaxLength(20);
        }
    }
}
