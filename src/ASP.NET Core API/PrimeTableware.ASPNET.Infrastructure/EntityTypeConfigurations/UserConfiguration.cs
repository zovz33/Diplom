using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeTableware.ASPNET.Domain.Entities;
using PrimeTableware.ASPNET.Infrastructure.Common.Base;

namespace PrimeTableware.ASPNET.Infrastructure.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey("Id");
            builder.HasIndex("Id").IsUnique(); 
            builder.Property(u => u.UserName).HasMaxLength(20);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
            builder.Property(user => user.Email).HasMaxLength(20);
            builder.HasIndex(user => user.Email).IsUnique(); 
            builder.Property(u => u.NormalizedEmail).HasMaxLength(256); 
            builder.Property(user => user.PasswordHash).HasMaxLength(20).IsRequired();


            builder.Property(user => user.PhoneNumber).HasMaxLength(20);
            builder.Property(user => user.FirstName).HasMaxLength(20);
            builder.Property(user => user.MiddleName).HasMaxLength(20);
            builder.Property(user => user.LastName).HasMaxLength(20);
            builder.Property(user => user.Gender).HasMaxLength(1);
            builder.Property(user => user.Address).HasMaxLength(30); 
            builder.Property(user => user.ProfileImage).HasMaxLength(200);

            builder.Property("CreatedBy").HasMaxLength(20);
            builder.Property("CreatedDateTime").IsRequired();
            builder.Property("LastUpdatedBy").HasMaxLength(20);
            builder.Property("UpdatedDateTime");
        }
    }
}
 