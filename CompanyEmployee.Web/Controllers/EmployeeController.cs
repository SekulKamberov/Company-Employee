using CompanyEmployee.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CompanyEmployee.Web.Models;
using CompanyEmployee.Services.Contracts;
using CompanyEmployee.Web.Models.Employee;

namespace CompanyEmployee.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IApiClient client;

        public EmployeeController(IApiClient apiClient)
        {
            client = apiClient;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var allCompanys = await this.employeeService.
        //    return View(allCompanys);
        //}
 
        public async Task<IActionResult> Edit(int id)
        {
            var requestUrl = client.CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Employee/ById/" + id));
            var details = await client.GetAsync<EditEmployee>(requestUrl);
            return View(details);
        }

        [HttpPost]
        //[ValidateModelState]
        public IActionResult Edit(EditEmployee employee)
        {
            var requestUrl = client.CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Employee/Put"));
            var response = client.PostAsync(requestUrl, employee);
            return this.RedirectToAction("Index", "Home", new { id = employee.CompanyId });
        }

        //public async Task<IActionResult> Details(int id)
        //{
        //    var companyDetails = await this.employeeService.Details(id);
        //    return View(companyDetails);
        //}

        public IActionResult Delete(int id) => View(id);

        public async Task<IActionResult> Destroy(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Not a valid Employee");
            }
            var requestUrl = client.CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Employee/" + id));
            await client.DeleteAsync(requestUrl);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult Create(int id)
            => this.View(new CreateEmployee { CompanyId = id });

        [HttpPost]
        public IActionResult Create(CreateEmployee model)
        {
            var requestUrl = client.CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Employee"));
            var response = client.PostAsync(requestUrl, model);
            return this.RedirectToAction("Index", "Home", new { id = model.CompanyId });
        } 
    }
}

