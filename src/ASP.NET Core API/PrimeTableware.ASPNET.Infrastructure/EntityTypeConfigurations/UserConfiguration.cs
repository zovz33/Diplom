using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeTableware.ASPNET.Domain.Entities;

namespace PrimeTableware.ASPNET.Infrastructure.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);
            builder.HasIndex(user => user.Id).IsUnique();
            builder.Property(user => user.UserName).HasMaxLength(20);

            builder.Property(user => user.Email).HasMaxLength(20);
            builder.HasIndex(user => user.Email).IsUnique();

            builder.Property(user => user.PasswordHash).IsRequired();
            builder.Property(user => user.RoleId).IsRequired();
            builder.Property(user => user.MobilePhone).HasMaxLength(15);
            builder.Property(user => user.FirstName).HasMaxLength(50);
            builder.Property(user => user.MiddleName).HasMaxLength(50);
            builder.Property(user => user.LastName).HasMaxLength(50);
            builder.Property(user => user.Gender).HasMaxLength(10);
            builder.Property(user => user.Address).HasMaxLength(100);
            builder.Property(user => user.HomePhone).HasMaxLength(15);

            builder.Property(user => user.CreatedBy).HasMaxLength(20);
            builder.Property(user => user.CreatedDateTime).IsRequired();
            builder.Property(user => user.LastUpdatedBy).HasMaxLength(20);
        }
    }
}
 