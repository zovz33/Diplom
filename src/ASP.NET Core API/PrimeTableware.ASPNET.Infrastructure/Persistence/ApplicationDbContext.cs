using Microsoft.EntityFrameworkCore;
using PrimeTableware.ASPNET.Application.Interfaces;
using PrimeTableware.ASPNET.Domain;
using PrimeTableware.ASPNET.Domain.Entities;
using PrimeTableware.ASPNET.Infrastructure.EntityTypeConfigurations;

namespace PrimeTableware.ASPNET.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
