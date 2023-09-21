using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeTableware.ASPNET.Domain.Entities
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatedByUserId { get; set; }
        public int EditedByUserId { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime DateEdit { get; set; }
        [InverseProperty("Roles")]
        public List<Permission> Permissions { get; set; }

    }
}
