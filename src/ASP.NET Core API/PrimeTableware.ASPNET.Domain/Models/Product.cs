using System;
using System.ComponentModel.DataAnnotations;

namespace PrimeTableware.ASPNET.Domain
{
    public class Product
    {
        [Key]
        public int idProduct { get; set; }        // айди товара
        public string NameProduct { get; set; }   // имя товара
        public decimal ProductPrice { get; set; } // цена товара
        public int InStockProduct { get; set; }   // скок в наличии едениц товара 
        public string TypeOfProduct { get; set; }       // Тип товара , у нас это сковородки/кастрюли и тд 
        public string ImageProduct { get; set; }        // Изображение товара 
        public string DiscriptionProduct { get; set; }  // Описание товара вообщем, 250 символов - максимум 
        public DateTime DateAdd { get; set; }    // Дата добавление товара в базу
        public DateTime DateEdit { get; set; }    // Дата редактирования товара в базе
    }
}
