using System;
using System.ComponentModel.DataAnnotations;

namespace PrimeTableware.ASPNET.Domain
{
    public class Card
    {
        [Key]
        public int idCard { get; set; }
        [Required]
        public int idUser { get; set; }
        public string CardNumber { get; set; }
        public string NameOwner { get; set; }
        public string SurnameOwner { get; set; }
        public string CVC { get; set; }
        public DateTime CardDateExpiration { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime DateEdit { get; set; }
    }
}