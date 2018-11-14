using CompanyEmployee.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CompanyEmployee.Services.Models
{
    public class CompanyServiceModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime Founded { get; set; }

        [Required]
        public string Information { get; set; }

        public IEnumerable<Employee> Employees { get; set; } = new List<Employee>();
    }
}
