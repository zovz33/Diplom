using System;

namespace PrimeTableware.WPF.Models
{
    public class CardModel
    {
        public int idCard { get; set; }
        public int idUser { get; set; }
        public string CardNumber { get; set; }
        public string NameOwner { get; set; }
        public string SurnameOwner { get; set; }
        public string CVC { get; set; }
        public DateTime CardDate { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime DateEdit { get; set; }
    }
}