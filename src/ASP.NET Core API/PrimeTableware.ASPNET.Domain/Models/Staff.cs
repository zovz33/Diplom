using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PrimeTableware.ASPNET.Domain
{
    public class Staff
    {
        [Key]
        public int idEmployee { get; set; }
        public int idUser { get; set; }
        public int idPosition { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime DateEdit { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateTerminated { get; set; }
    }
}
