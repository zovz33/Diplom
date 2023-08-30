using System;
using System.ComponentModel.DataAnnotations;

namespace PrimeTableware.ASPNET.Domain
{
    public class UserAccount

    {
        [Key]
        public int UserIDModel { get; set; }
        public string UsernameSurnameModel { get; set; }
        public string NameModel { get; set; }
        public string SurnameModel { get; set; }
        public string LoginModel { get; set; }
        public string UserRoleModel { get; set; }
        public string MailModel { get; set; }
        public string MobilePhoneModel { get; set; }
        public string FNameModel { get; set; }
        public string GenderModel { get; set; }
        public string AdressModel { get; set; }
        public string HomePhoneModel { get; set; }
        public string ImageModel { get; set; }
        public DateTime DateOfBornModel { get; set; }
        public DateTime DateAddModel { get; set; }
        public DateTime DateEditModel { get; set; } // Дата изменения пользователем/администратором данных пользователя
    }
}
