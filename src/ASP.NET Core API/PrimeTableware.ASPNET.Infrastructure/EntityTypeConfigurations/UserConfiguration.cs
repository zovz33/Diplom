using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeTableware.ASPNET.Domain.Entities;
using PrimeTableware.ASPNET.Infrastructure.Common.Base;

namespace PrimeTableware.ASPNET.Infrastructure.EntityTypeConfigurations
{
    public class UserConfiguration : BaseEntityTypeConfiguration<User>
    {

        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.Property(user => user.UserName).HasMaxLength(20);

            builder.Property(user => user.Email).HasMaxLength(20);
            builder.HasIndex(user => user.Email).IsUnique();

            builder.Property(user => user.PasswordHash).HasMaxLength(20).IsRequired();

            builder.Property(user => user.RoleId).HasDefaultValue(1);

            builder.Property(user => user.MobilePhone).HasMaxLength(20);
            builder.Property(user => user.FirstName).HasMaxLength(20);
            builder.Property(user => user.MiddleName).HasMaxLength(20);
            builder.Property(user => user.LastName).HasMaxLength(20);
            builder.Property(user => user.Gender).HasMaxLength(1);
            builder.Property(user => user.Address).HasMaxLength(30);
            builder.Property(user => user.HomePhone).HasMaxLength(15);
            builder.Property(user => user.ProfileImage).HasMaxLength(200);

        }
    }
}
 