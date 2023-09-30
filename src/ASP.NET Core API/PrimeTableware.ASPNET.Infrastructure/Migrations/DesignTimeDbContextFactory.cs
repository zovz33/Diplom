using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using PrimeTableware.ASPNET.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;

namespace PrimeTableware.ASPNET.Infrastructure.Migrations
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext> 
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
 
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=LENOVO\\SQLEXPRESS01;Initial Catalog=KatushaDataBase;User Id=1;Password=1;TrustServerCertificate=True");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}