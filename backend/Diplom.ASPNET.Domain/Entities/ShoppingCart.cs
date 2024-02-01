using System.ComponentModel.DataAnnotations.Schema;
using Diplom.ASPNET.Domain.Entities.Base;
using Diplom.ASPNET.Domain.Entities.Identity;

namespace Diplom.ASPNET.Domain.Entities;

public class ShoppingCart : BaseEntity
{
    [ForeignKey("UserId")] 
    public int UserId { get; set; }

    public virtual User User { get; set; }

    [ForeignKey("ProductId")] 
    public int ProductId { get; set; }

    public virtual Product Product { get; set; }

    public int Quantity { get; set; }
 
}