using System.ComponentModel.DataAnnotations;

namespace PrimeTableware.ASPNET.Domain
{
    public class Payment
    {
        [Key]
        public int idPayment { get; set; }

        public int idCard { get; set; } // id карты из отдельной таблицы
        public string StatusPayment { get; set; } = "";
        public decimal TotalCost { get; set; } // Итоговая сумма
        public DateTime DateAdd { get; set; }
        public DateTime DateEdit { get; set; }

    }
}
