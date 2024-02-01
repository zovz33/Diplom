using Microsoft.AspNetCore.Identity;

namespace Diplom.ASPNET.Domain.Entities.Identity;

public class UserToken : IdentityUserToken<int>
{
    public virtual User User { get; set; }
}