using System;

namespace PrimeTableware.WPF.Models
{
    public class OrderModel
    {
        public int idOrder { get; set; }
        public int idProduct { get; set; }
        public int idUser { get; set; }
        public int Amount { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime DateEdit { get; set; }
    }
}