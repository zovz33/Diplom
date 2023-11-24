using Microsoft.AspNetCore.Identity;

namespace PrimeTableware.ASPNET.Domain.Entities
{
    public class Role : IdentityRole<int>
    {
        public string Description { get; set; }
    }
}
