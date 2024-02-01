using Diplom.ASPNET.Domain.Entities;
using Diplom.ASPNET.Infrastructure.Common.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diplom.ASPNET.Infrastructure.EntityTypeConfigurations;

public class OrderConfiguration : BaseEntityTypeConfiguration<Order>
{
    public override void Configure(EntityTypeBuilder<Order> builder)
    {
        base.Configure(builder);

        builder.Property(user => user.Name).HasMaxLength(20);
        builder.Property(order => order.TotalAmount).HasColumnType("decimal(18, 0)").IsRequired();
    }
}