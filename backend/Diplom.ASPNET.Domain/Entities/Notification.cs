using System.ComponentModel.DataAnnotations.Schema;
using Diplom.ASPNET.Domain.Entities.Base;
using Diplom.ASPNET.Domain.Entities.Identity;

namespace Diplom.ASPNET.Domain.Entities;

public class Notification : BaseEntity
{
    public string Content { get; set; }

    // Статус уведомления (например, "Unread", "Read")
    public string Status { get; set; }

    // Тип уведомления (например, "OrderStatus", "Promotion", "SystemAlert" и т.д.)
    public string NotificationType { get; set; }

    [ForeignKey("UserId")] public int UserId { get; set; }

    public virtual User User { get; set; }
}