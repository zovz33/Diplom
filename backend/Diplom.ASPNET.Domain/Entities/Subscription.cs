using Diplom.ASPNET.Domain.Entities.Base;
using Diplom.ASPNET.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplom.ASPNET.Domain.Entities
{
    public class Subscription : BaseEntity
    {
        // Ссылка на пользователя, подписанного на товар
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        // Ссылка на товар, на который подписан пользователь
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        // public bool IsActive { get; set; } 
    }
}