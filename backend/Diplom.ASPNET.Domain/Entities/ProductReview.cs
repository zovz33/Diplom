using System.ComponentModel.DataAnnotations.Schema;
using Diplom.ASPNET.Domain.Entities.Base;
using Diplom.ASPNET.Domain.Entities.Identity;

namespace Diplom.ASPNET.Domain.Entities;

public class ProductReview : BaseEntity
{
    public string Content { get; set; }
    public int Rating { get; set; }

    // Ссылка на пользователя, оставившего отзыв
    [ForeignKey("UserId")] public int UserId { get; set; }

    public virtual User User { get; set; }

    // Ссылка на товар, к которому относится отзыв
    [ForeignKey("ProductId")] public int ProductId { get; set; }

    public virtual Product Product { get; set; }

    // Дата и время создания отзыва
    public DateTime ReviewDateTime { get; set; }

    // Дополнительные поля, если необходимо
    // public bool IsApproved { get; set; } // Пример: одобрен ли отзыв администратором
    // public bool IsAnonymous { get; set; } // Пример: анонимный ли отзыв
}