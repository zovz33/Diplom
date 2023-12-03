using Diplom.ASPNET.Domain.Entities.Base;
using Diplom.ASPNET.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplom.ASPNET.Domain.Entities
{
    public class Cart : BaseEntity
    {

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        // public bool IsCheckedOut { get; set; } // Пример: отмечено ли оформление заказа
    }
}
