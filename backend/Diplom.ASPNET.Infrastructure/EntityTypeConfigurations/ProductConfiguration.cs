using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Diplom.ASPNET.Domain.Entities;
using Diplom.ASPNET.Infrastructure.Common.Base;

namespace Diplom.ASPNET.Infrastructure.EntityTypeConfigurations
{
    public class ProductConfiguration : BaseEntityTypeConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.Property(user => user.Name).HasMaxLength(20);
            builder.Property(user => user.Description).HasMaxLength(128);
        }
    }
}
