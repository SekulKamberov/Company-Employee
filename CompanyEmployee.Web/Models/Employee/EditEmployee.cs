using CompanyEmployee.Data.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace CompanyEmployee.Web.Models.Employee
{
    public class EditEmployee
    {
        public int Id { get; set; }

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

        [Required]
        public int CompanyId { get; set; }
    }
}
