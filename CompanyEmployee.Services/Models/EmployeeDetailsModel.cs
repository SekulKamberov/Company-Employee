namespace CompanyEmployee.Services.Models
{
    using CompanyEmployee.Common.Mapping;
    using CompanyEmployee.Data.Models.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class EmployeeDetailsModel : IMapFrom<Employee>
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Experience Level { get; set; }

        [Required]
        public DateTime StartingDate { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public int VacationDays { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
