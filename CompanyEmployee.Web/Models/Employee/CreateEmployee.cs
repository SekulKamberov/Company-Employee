using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployee.Web.Models.Employee
{
    public class CreateEmployee
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Experience Experience { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartingDate { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public int VacationDays { get; set; }

        public int CompanyId { get; set; }
    }
}
