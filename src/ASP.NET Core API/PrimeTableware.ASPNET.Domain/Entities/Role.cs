using PrimeTableware.ASPNET.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeTableware.ASPNET.Domain.Entities
{
    [Table("Roles")]
    public class Role : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [InverseProperty("Roles")]
        public List<Permission> Permissions { get; set; }

        [InverseProperty("Roles")]
        public List<User> Users { get; set; }

    }
}
