using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Diplom.ASPNET.Domain.Entities.Identity
{
    public class UserLogin : IdentityUserLogin<int>
    { 

        public virtual User User { get; set; }
    }
}
