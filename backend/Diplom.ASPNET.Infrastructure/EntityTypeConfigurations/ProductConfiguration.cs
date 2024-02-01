using Diplom.ASPNET.Domain.Entities;
using Diplom.ASPNET.Infrastructure.Common.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diplom.ASPNET.Infrastructure.EntityTypeConfigurations;

public class ProductConfiguration : BaseEntityTypeConfiguration<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        base.Configure(builder);
        builder.Property(product => product.Name)
            .HasMaxLength(50)
            .IsRequired();
        builder.HasIndex(product => product.Name)
            .IsUnique();
        builder.Property(product => product.Description)
            .HasMaxLength(200);
        builder.Property(product => product.Price)
            .IsRequired();
        builder.Property(product => product.Quantity)
            .IsRequired();
        builder.Property(product => product.Category)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(product => product.ImageUrl)
            .HasMaxLength(200); 
    }
}