using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrimeTableware.ASPNET.Application.Interfaces;
using PrimeTableware.ASPNET.Domain.Entities;
using PrimeTableware.ASPNET.Domain.Entities.Identity;
using System.Reflection;
using System.Reflection.Emit;

namespace PrimeTableware.ASPNET.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>, IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Log> Logs { get; set; } 
        public DbSet<Notification> Notifications { get; set; } 
        public DbSet<ProductReview> ProductReviews { get; set; } 
        public DbSet<Subscription> Subscriptions { get; set; } 


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(entity => entity.ToTable(name: "Users"));
            builder.Entity<Role>(entity => entity.ToTable(name: "Roles"));
            builder.Entity<IdentityUserRole<int>>(entity =>
                entity.ToTable(name: "UserRoles"));
            builder.Entity<IdentityUserClaim<int>>(entity =>
                entity.ToTable(name: "UserClaim"));
            builder.Entity<IdentityUserLogin<int>>(entity =>
                entity.ToTable("UserLogins"));
            builder.Entity<IdentityUserToken<int>>(entity =>
                entity.ToTable("UserTokens"));
            builder.Entity<IdentityRoleClaim<int>>(entity =>
                entity.ToTable("RoleClaims"));
            builder.Entity<Order>(entity => entity.ToTable(name: "Orders")); 
            builder.Entity<Product>(entity => entity.ToTable(name: "Products")); 
            builder.Entity<Log>(entity => entity.ToTable(name: "Logs")); 
            builder.Entity<Notification>(entity => entity.ToTable(name: "Notifications")); 
            builder.Entity<ProductReview>(entity => entity.ToTable(name: "ProductReviews")); 
            builder.Entity<Subscription>(entity => entity.ToTable(name: "Subscriptions")); 

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
