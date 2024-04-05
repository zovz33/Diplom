using Diplom.ASPNET.Domain.Entities;
using Diplom.ASPNET.Infrastructure.Common.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diplom.ASPNET.Infrastructure.EntityTypeConfigurations;

public class LogConfiguration : BaseEntityTypeConfiguration<Log>
{
    public override void Configure(EntityTypeBuilder<Log> builder)
    {
        base.Configure(builder);

        builder.Property(entity => entity.Message).HasMaxLength(256).IsRequired();
        builder.Property(entity => entity.LogLevel).IsRequired();
    }
}