namespace CompanyEmployee.Services.Models
{
    using System;
    using CompanyEmployee.Data.Models.Entities;
    using System.ComponentModel.DataAnnotations;

    public class EmployeeRequestModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        [Display(Name = "Experience")]
        public Experience Experience { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Starting Date")]
        public DateTime StartingDate { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public int VacationDays { get; set; }

        public int CompanyId { get; set; }
    }
}
