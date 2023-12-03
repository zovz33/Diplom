using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PrimeTableware.ASPNET.Domain.Entities.Base;

namespace PrimeTableware.ASPNET.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public string Category { get; set; }
        public bool InStock { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ProductReview> Reviews { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}