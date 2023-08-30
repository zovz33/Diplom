using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PrimeTableware.ASPNET.Domain
{
    public class Department
    {
        [Key]
        public int idDepartment { get; set; }
        public string NameDepartment { get; set; }
        public string DescriptionDepartment { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime DateEdit { get; set; }

    }
}
