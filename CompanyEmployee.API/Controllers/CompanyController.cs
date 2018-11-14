namespace CompanyEmployee.API.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Routing;

    using CompanyEmployee.Services.Models;
    using CompanyEmployee.Services.Contracts;
    using CompanyEmployee.API.Infrastructure.Filters;
    using CompanyEmployee.API.Infrastructure.Extensions;
    
    public class CompanyController : BaseApiController
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => this.OkOrNotFound(await this.companyService.All());

        [HttpGet]
        [Route("{id:int:min(1)}")]
        public async Task<IActionResult> Get(int id)
           => this.OkOrNotFound(await this.companyService.Details(id));


        [HttpDelete("{id:int:min(1)}")]
        public async Task<IActionResult> Delete(int id)
        {
            var companyExists = await this.companyService.Exists(id);
            if (!companyExists)
            {
                return NotFound("Company does not exist.");
            }
            await this.companyService.DeleteEmployees(id);
            await this.companyService.Delete(id);
            return this.Ok();
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromBody]CompanyRequestModel model)
        {
            var categoryNameExists = await this.companyService.Exists(model.Name);
            if (categoryNameExists)
            {
                this.ModelState.AddModelError(nameof(CompanyRequestModel.Name), "Company name already exists.");
                return BadRequest(this.ModelState);
            }
            await this.companyService.Create(model);

            return this.Ok();
        }

        [HttpPost]
        [Route(nameof(Put))]
        [ValidateModelState]
        public async Task<IActionResult> Put([FromBody]CompanyRequestModel model)
        {
            var companyExists = await this.companyService.Exists(model.Id);
            if (!companyExists)
            {
                this.ModelState.AddModelError(nameof(CompanyRequestModel.Name), "Company name does not exists");
                return BadRequest(this.ModelState);
            }
            await this.companyService.Update(model);
            return this.Ok();
        }
    }
}
