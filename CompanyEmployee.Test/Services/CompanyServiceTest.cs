namespace CompanyEmployee.Test.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    using Xunit;
    using FluentAssertions;

    using CompanyEmployee.Data;
    using CompanyEmployee.Data.Models.Entities;
    using CompanyEmployee.Services;
    using CompanyEmployee.Services.Models;
    using CompanyEmployee.Web.Models;
    using CompanyEmployee.Web.Models.Company;
    using Company = Web.Models.Company;

    public class CompanyServiceTest
    {
        [Fact]
        public async Task CreateCompanyShouldSaveCorrectData()
        {
            // Arrange
            var db = this.GetDatabase();
            const int Id = 1;
            const string Name = "Star Sechko";
            const string Information = "Some company information.";

            var companyService = new CompanyService(db);

            var model = new CompanyRequestModel
            {
                Id = 1,
                Name = Name,
                Founded = DateTime.MaxValue, 
                Information = Information,
            };

            // Act
            await companyService.Create(model);
            var result = await db.Companys.FindAsync(Id);

            // Assert
            Assert.Equal(Id, result.Id);
            Assert.Equal(Name, result.Name);
            Assert.Equal(Information, result.Information);
        }

        private CompanyEmployeeDBContext GetDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<CompanyEmployeeDBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new CompanyEmployeeDBContext(dbOptions);
        }
    }
}
