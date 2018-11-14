namespace CompanyEmployee.Web.Models.Company
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EditCompany
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Founded { get; set; }

        [Required]
        [MaxLength(100)]
        public string Information { get; set; }
    }
}
