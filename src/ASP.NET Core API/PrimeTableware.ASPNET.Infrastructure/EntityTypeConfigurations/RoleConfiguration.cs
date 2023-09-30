using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeTableware.ASPNET.Domain.Entities;
using PrimeTableware.ASPNET.Infrastructure.Common.Base;


namespace PrimeTableware.ASPNET.Infrastructure.EntityTypeConfigurations
{
    public class RoleConfiguration : BaseEntityTypeConfiguration<Role>
    {

        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);
            builder.Property(user => user.Name).HasMaxLength(20);

        }
    }
}
