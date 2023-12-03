﻿using PrimeTableware.ASPNET.Domain.Entities.Base;
using PrimeTableware.ASPNET.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeTableware.ASPNET.Domain.Entities
{
    public class Log : BaseEntity
    {
        public string ActionType { get; set; } // Тип действия пользователя (например, "Login", "Logout", "Purchase", "UpdateProfile" и т.д.)
        public string LogLevel { get; set; }
        public string Message { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}