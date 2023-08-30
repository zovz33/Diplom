using System;
using System.ComponentModel.DataAnnotations.Schema;
using PrimeTableware.WPF.Models;
using PrimeTableware.WPF.Repositories;

namespace PrimeTableware.WPF.Models
{
    public class StaffModel
    {
 
        public int idEmployee { get; set; }
        public int idUser { get; set; }
        public int idPosition { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime DateEdit { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateTerminated { get; set; }
    }
}
