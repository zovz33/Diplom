using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeTableware.ASPNET.Domain.Entities;
using PrimeTableware.ASPNET.Infrastructure.Common.Base;

namespace PrimeTableware.ASPNET.Infrastructure.EntityTypeConfigurations
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
