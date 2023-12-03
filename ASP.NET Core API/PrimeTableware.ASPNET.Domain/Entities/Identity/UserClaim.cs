using Microsoft.AspNetCore.Identity;

namespace PrimeTableware.ASPNET.Domain.Entities.Identity
{
    public class UserClaim : IdentityUserClaim<int>
    {

        public virtual User User { get; set; }
    }
}
