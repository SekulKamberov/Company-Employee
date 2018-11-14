namespace CompanyEmployee.Services.Contracts
{
    using CompanyEmployee.Data.Models.Entities;
    using CompanyEmployee.Services.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICompanyService
    {
        Task<IEnumerable<AllCompanyModel>> All();

        Task Create(CompanyRequestModel model);

        Task<CompanyServiceModel> Details(int id);

        Task Delete(int id);

        Task DeleteEmployees(int id);

        Task<bool> Exists(int id);

        Task<bool> Exists(int id, string name);

        Task<bool> Exists(string name);

        Task Update(CompanyRequestModel model);
    }
}
