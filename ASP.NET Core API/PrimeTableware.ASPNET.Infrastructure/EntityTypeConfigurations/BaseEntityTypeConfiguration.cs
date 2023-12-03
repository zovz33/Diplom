using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PrimeTableware.ASPNET.Domain.Entities.Base;

namespace PrimeTableware.ASPNET.Infrastructure.Common.Base
{
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
}
