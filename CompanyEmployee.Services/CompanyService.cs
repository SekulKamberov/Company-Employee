using AutoMapper.QueryableExtensions;
using CompanyEmployee.Data;
using CompanyEmployee.Data.Models.Entities;
using CompanyEmployee.Services.Contracts;
using CompanyEmployee.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployee.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CompanyEmployeeDBContext db;

        public CompanyService(CompanyEmployeeDBContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AllCompanyModel>> All()
            => await this.db
            .Companys
            .ProjectTo<AllCompanyModel>()
            .ToListAsync();

        public async Task Create(CompanyRequestModel model)
        {
            var company = new Company
            {
                Name = model.Name,
                Founded = model.Founded,
                Information = model.Information,
            };

            await this.db.Companys.AddAsync(company);
            await this.db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var company = await this.db.Companys.FindAsync(id);
            if (company == null)
            {
                return;
            }
            this.db.Remove(company);
            await this.db.SaveChangesAsync();
        }

        public async Task DeleteEmployees(int id)
        {
            var employees = await this.db.Employees.Where(c => c.CompanyId == id).ToListAsync<Employee>();
            this.db.RemoveRange(employees);
            await this.db.SaveChangesAsync();
        }

        public async Task<CompanyServiceModel> Details(int id)
            => await this.db
            .Companys
            .Where(c => c.Id == id)
            .ProjectTo<CompanyServiceModel>()
            .FirstOrDefaultAsync();

        public async Task<bool> Exists(int id)
            => await this.db
            .Companys
            .AnyAsync(c => c.Id == id);

        public async Task<bool> Exists(int id, string name)
            => await this.db
            .Companys
            .Where(c => c.Id == id)
            .AnyAsync(c => c.Name.ToLower() == name.ToLower());

        public async Task<bool> Exists(string name)
            => await this.db
            .Companys
            .AnyAsync(c => c.Name.ToLower() == name.ToLower());

        public async Task Update(CompanyRequestModel model)
        {
            var company = await this.db.Companys.FindAsync(model.Id);
            if (company == null)
            {
                return;
            }

            if (company.Name != model.Name || 
                company.Information != model.Information ||
                company.Founded != model.Founded)
            {
                company.Id = model.Id;
                company.Name = model.Name;
                company.Founded = model.Founded;
                company.Information = model.Information;

                await this.db.SaveChangesAsync();
            } 
        }
    }
}