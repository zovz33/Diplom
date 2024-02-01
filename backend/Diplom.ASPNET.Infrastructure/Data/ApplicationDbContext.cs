using System.Reflection;
using Diplom.ASPNET.Application.Interfaces;
using Diplom.ASPNET.Domain.Entities;
using Diplom.ASPNET.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Diplom.ASPNET.Infrastructure.Data;

public class ApplicationDbContext :
    IdentityDbContext<User, Role, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Log> Logs { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<ProductReview> ProductReviews { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<ShoppingCart> ShoppingCart { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>(entity => entity.ToTable("Users"));
        builder.Entity<Role>(entity => entity.ToTable("Roles"));
        builder.Entity<IdentityUserRole<int>>(entity =>
            entity.ToTable("UserRoles"));
        builder.Entity<IdentityUserClaim<int>>(entity =>
            entity.ToTable("UserClaim"));
        builder.Entity<IdentityUserLogin<int>>(entity =>
            entity.ToTable("UserLogins"));
        builder.Entity<IdentityUserToken<int>>(entity =>
            entity.ToTable("UserTokens"));
        builder.Entity<IdentityRoleClaim<int>>(entity =>
            entity.ToTable("RoleClaims"));
        builder.Entity<Order>(entity => entity.ToTable("Orders"));
        builder.Entity<Product>(entity => entity.ToTable("Products"));
        builder.Entity<Log>(entity => entity.ToTable("Logs"));
        builder.Entity<Notification>(entity => entity.ToTable("Notifications"));
        builder.Entity<ProductReview>(entity => entity.ToTable("ProductReviews"));
        builder.Entity<Subscription>(entity => entity.ToTable("Subscriptions"));
        builder.Entity<ShoppingCart>(entity => entity.ToTable("ShoppingCart"));
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}