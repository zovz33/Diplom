using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeTableware.ASPNET.Domain;

namespace PrimeTableware.ASPNET.Infrastructure.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.idUser);
            builder.HasIndex(user => user.idUser).IsUnique();
            builder.Property(user => user.Name).HasMaxLength(20);
        }
    }
}
