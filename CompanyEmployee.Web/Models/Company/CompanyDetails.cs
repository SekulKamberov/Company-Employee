namespace CompanyEmployee.Web.Models.Company
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using CompanyEmployee.Web.Models.Employee;

    public class CompanyDetails
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Company")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Founded { get; set; }

        [Required]
        [MaxLength(100)]
        public string Information { get; set; }

        public IEnumerable<Employee> Employees { get; set; } = new List<Employee>();
    }
}
