namespace CompanyEmployee.Data
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    using CompanyEmployee.Data.Models.Entities;

    public class CompanyEmployeeDBContext : DbContext
    {
        public CompanyEmployeeDBContext(DbContextOptions<CompanyEmployeeDBContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Company> Companys { get; set; }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>()
                .HasMany(a => a.Employees)
                .WithOne(b => b.Company)
                .HasForeignKey(b => b.CompanyId);
        }
    }
}
