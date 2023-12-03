using Microsoft.EntityFrameworkCore;
using Diplom.ASPNET.Domain.Entities;
using Diplom.ASPNET.Domain.Entities.Identity;

namespace Diplom.ASPNET.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Log> Logs { get; set; }
        DbSet<Notification> Notifications { get; set; }
        DbSet<ProductReview> ProductReviews { get; set; }
        DbSet<Subscription> Subscriptions { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
