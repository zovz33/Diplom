using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeTableware.WPF.Repositories;

namespace PrimeTableware.WPF.Models
{
    public class PositionModel
    {
        public int idPosition { get; set; }
        public string NamePosition { get; set; }
        public decimal Salary { get; set; }
        public int MaxNumber { get; set; } // максимальное количество "вакансий"
        public int idDepartment { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime DateEdit { get; set; }
        public string DescriptionPosition { get; set; }
    }
}
