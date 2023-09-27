using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PrimeTableware.ASPNET.Domain.Entities.Base;

namespace PrimeTableware.ASPNET.Domain.Entities
{
    [Table("Permissions")]
    public class Permission : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [InverseProperty("Permissions")]
        public List<Role> Roles { get; set; }
    }
}