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
        }
    }
}
