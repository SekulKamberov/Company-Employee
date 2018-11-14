namespace CompanyEmployee.Web.Models.Company
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using CompanyEmployee.Web.Models.Employee;

    public class Companies
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Founded { get; set; }

        [Required]
        public string Information { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
    }
}
