using Diplom.ASPNET.Domain.Entities.Base;
using Diplom.ASPNET.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplom.ASPNET.Domain.Entities
{
    
    public class Order : BaseEntity
    {
        public string Name { get; set; }
        public decimal TotalAmount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public OrderStatus Status { get; set; }

        // Ссылка на пользователя, сделавшего заказ
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
    public enum OrderStatus
    {
        Processing = 1,
        Delivery = 2,
        Finished = 3
    }

    public enum PaymentMethod
    {
        Check = 1,
        BankTransfer = 2,
        Cash = 3,
        Paypal = 4,
        Payoneer = 5
    }
}
