namespace CompanyEmployee.Services.Contracts
{
    using CompanyEmployee.Data.Models.Entities;
    using CompanyEmployee.Services.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IEmployeeService
    {
        EmployeeFullDetailsModel EmployeeById(int id);

        void Edit(EmployeeDetailsModel member);

        Task<bool> Exists(int id);

        Task Create(EmployeeRequestModel model);

        Task Update(EmployeeRequestModel model);

        Task Delete(int id);

        Task<IEnumerable<Employee>> EmployeesInCompany(int Id);
    }
}
