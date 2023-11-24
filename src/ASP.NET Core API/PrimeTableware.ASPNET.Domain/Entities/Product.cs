using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PrimeTableware.ASPNET.Domain.Entities.Base;

namespace PrimeTableware.ASPNET.Domain.Entities
{
    [Table("Products")]
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        //[InverseProperty("Products")]
        //public List<Order> Orders { get; set; }
    }
}