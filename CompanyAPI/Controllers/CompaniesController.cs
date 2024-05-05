


using Microsoft.AspNetCore.Mvc;
using CompanyAPI.Interfaces;
using CompanyAPI.Models;



namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private ICompany _companyService;

        public CompaniesController(ICompany companyService)
        {
            _companyService = companyService;
        }
        // GET: api/<CompaniesController>
        [HttpGet]
        public async Task<IEnumerable<Company>> Get()
        {
            var companies = await _companyService.GetAllCompanies();
            return companies;
        }

        // GET api/<CompaniesController>/5
        [HttpGet("{id}")]
        public async Task<Company> Get(int id)
        {
            return await _companyService.GetCompanyById(id);
        }

        // POST api/<CompaniesController>
        [HttpPost]
        public async Task Post([FromBody] Company company)
        {
            await _companyService.AddCompany(company);
        }

        // PUT api/<CompaniesController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Company company)
        {
            await _companyService.UpdateCompany(id, company);
        }

        // DELETE api/<CompaniesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _companyService.DeleteCompany(id);
        }

        

    }
}
