namespace CompanyEmployee.Services.Models
{
    using CompanyEmployee.Data.Models.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CompanyRequestModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Founded")]
        public DateTime Founded { get; set; }

        [Required]
        public string Information { get; set; }

        public IEnumerable<Employee> Employees { get; set; } = new List<Employee>();
    }
}
