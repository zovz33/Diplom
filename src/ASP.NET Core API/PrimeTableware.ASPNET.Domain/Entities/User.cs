using PrimeTableware.ASPNET.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeTableware.ASPNET.Domain.Entities
{
    [Table("Users")]
    public class User : BaseEntity
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string? MobilePhone { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? HomePhone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ProfileImage { get; set; }

        [InverseProperty("Users")]
        public List<Role> Roles { get; set; }
    }
}
