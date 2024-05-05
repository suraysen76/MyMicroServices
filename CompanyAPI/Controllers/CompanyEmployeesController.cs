
using Microsoft.AspNetCore.Mvc;
using CompanyAPI.Interfaces;
using CompanyAPI.Models;

namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyEmployeesController : ControllerBase
    {
        private ICompany _companyService;
        public CompanyEmployeesController(ICompany companyService)
        {
            _companyService = companyService;
        }
        [HttpGet]
        public async Task<IEnumerable<CompanyEmployees>> GetCompanyEmployees()
        {
            var companies = await _companyService.GetAllCompanyEmployees();
            return companies;
        }
        [HttpGet("{id}")]
        public async Task<IEnumerable<CompanyEmployees>> GetCompanyEmployeesByCompanyId(int id)
        {
            return await _companyService.GetCompanyEmployeesByCompanyId(id);
        }
        [HttpPost]
        public async Task Post([FromBody] CompanyEmployees companyEmployee)
        {
            await _companyService.AddCompanyEmployee(companyEmployee);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] CompanyEmployees companyEmployees)
        {
            await _companyService.UpdateCompanyEmployee(id, companyEmployees);
        }
        [HttpDelete("{id}")]
        public async Task DeleteCompanyEmployee(int id)
        {
            await _companyService.DeleteCompanyEmployee(id);
        }
    }
}
