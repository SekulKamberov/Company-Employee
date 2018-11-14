namespace CompanyEmployee.Web.Models.Company
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class CreateCompany
    {
        [Required]
        [Display(Name = "Company Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Founded { get; set; }

        [Required]
        public string Information { get; set; }
    }
}
