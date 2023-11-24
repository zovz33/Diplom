using PrimeTableware.ASPNET.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeTableware.ASPNET.Domain.Entities
{
    [Table("Orders")]
    public class Order : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        //[InverseProperty("Orders")]
        //public List<Product> Products { get; set; }

        //[InverseProperty("Orders")]
        //public List<User> Users { get; set; }

    }
}
