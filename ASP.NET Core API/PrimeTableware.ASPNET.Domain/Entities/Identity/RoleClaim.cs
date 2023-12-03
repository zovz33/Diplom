using Microsoft.AspNetCore.Identity;

namespace PrimeTableware.ASPNET.Domain.Entities.Identity
{
    public class RoleClaim : IdentityRoleClaim<int>
    {
        public virtual Role Role { get; set; }
    }
}