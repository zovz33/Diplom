using Microsoft.EntityFrameworkCore;
using PrimeTableware.ASPNET.Domain.Entities;

namespace PrimeTableware.ASPNET.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
