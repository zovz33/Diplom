using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeTableware.ASPNET.Domain.Entities.Identity
{
    public class UserRole : IdentityUserRole<int>
    {

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
