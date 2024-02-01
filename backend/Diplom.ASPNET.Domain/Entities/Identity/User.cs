using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Diplom.ASPNET.Domain.Entities.Identity;

public class User : IdentityUser<int>
{
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    [RegularExpression("^[MF]$", ErrorMessage = "Гендер должен быть 'M' или 'F'.")]
    public Gender? Gender { get; set; }
    public string? Address { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? ProfileImage { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
    public string? LastUpdatedBy { get; set; }
    public DateTime? UpdatedDateTime { get; set; }

    public virtual ICollection<Order> Orders { get; set; }

    public virtual ICollection<UserClaim> Claims { get; set; }
    public virtual ICollection<UserLogin> Logins { get; set; }
    public virtual ICollection<UserToken> Tokens { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; }
}
public enum Gender
{
    Male = 0,
    Female = 1,
}