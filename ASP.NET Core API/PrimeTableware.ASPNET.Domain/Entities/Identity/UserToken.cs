using Microsoft.AspNetCore.Identity;

namespace PrimeTableware.ASPNET.Domain.Entities.Identity
{
    public class UserToken : IdentityUserToken<int>
    {


        public virtual User User { get; set; }
    }
}
