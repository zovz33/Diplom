using Diplom.ASPNET.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diplom.ASPNET.Infrastructure.Common.Base;

public abstract class BaseEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        // Общая конфигурация для всех сущностей
        builder.HasKey("Id");
        builder.HasIndex("Id").IsUnique();
        builder.Property("CreatedBy").HasMaxLength(20);
        builder.Property("CreatedDateTime").IsRequired();
        builder.Property("LastUpdatedBy").HasMaxLength(20);
        builder.Property("UpdatedDateTime");
    }
}