using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Diplom.ASPNET.Domain.Entities;
using Diplom.ASPNET.Infrastructure.Common.Base;

namespace Diplom.ASPNET.Infrastructure.EntityTypeConfigurations
{
    public class OrderConfiguration : BaseEntityTypeConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            builder.Property(user => user.Name).HasMaxLength(20); 
        }
    }
}
