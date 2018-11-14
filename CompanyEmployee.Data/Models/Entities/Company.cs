namespace CompanyEmployee.Data.Models.Entities
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Company
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Founded { get; set; }

        [Required]
        public string Information { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
