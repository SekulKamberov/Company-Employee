namespace CompanyEmployee.API.Controllers
{
    using CompanyEmployee.API.Infrastructure.Extensions;
    using CompanyEmployee.API.Infrastructure.Filters;
    using CompanyEmployee.Services.Contracts;
    using CompanyEmployee.Services.Models;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class EmployeeController : BaseApiController
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [Route("ById/{id:int:min(1)}")]
        public IActionResult Get(int id)
           => this.OkOrNotFound(this.employeeService.EmployeeById(id));

        [HttpGet]
        [Route("{id:int:min(1)}")]
        public async Task<IActionResult> GetEmployees (int id)
         => this.OkOrNotFound(await this.employeeService.EmployeesInCompany(id));

        [HttpDelete("{id:int:min(1)}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employeeExist = await this.employeeService.Exists(id);
            if (!employeeExist)
            {
                return NotFound("Category does not exist.");
            }

            await this.employeeService.Delete(id);

            return this.Ok();
        }

        //[HttpGet("{id:int:min(1)}")]
        //public IActionResult Edit(int id)
        //{
        //    this.employeeService.EmployeeById(id);
        //    return this.Ok();
        //}
        [HttpPost]
        [Route(nameof(Put))]
        [ValidateModelState]
        public async Task<IActionResult> Put([FromBody]EmployeeRequestModel model)
        {
            var employeeExists = await this.employeeService.Exists(model.Id);
            if (!employeeExists)
            {
                return NotFound("Employee does not exist");
            }
            await this.employeeService.Update(model);
            return this.Ok();
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromBody]EmployeeRequestModel model)
        {
            await this.employeeService.Create(model);
            return Ok(model.CompanyId);
        }
    }
}
