using Microsoft.EntityFrameworkCore;
using PrimeTableware.ASPNET.Domain.Entities;

namespace PrimeTableware.ASPNET.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Permission> Permissions { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
