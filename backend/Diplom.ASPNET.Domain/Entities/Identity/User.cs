using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplom.ASPNET.Domain.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ProfileImage { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? UpdatedDateTime { get; set; }

        //public string? RefreshToken { get; set; }
        //public DateTime RefreshTokenExpiryTime { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<UserClaim> Claims { get; set; }
        public virtual ICollection<UserLogin> Logins { get; set; }
        public virtual ICollection<UserToken> Tokens { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }

    }
}
