
using MicroserviceWeb.Models;
using MicroserviceWeb.APIServices;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceWeb.Controllers
{
    public class CompaniesController : Controller
    {
        private List<Company> modelCompany { get; set; }
        private List<CompanyEmployees> modelCompanyEmployees;
        private List<Employee> modelEmployees ;
        protected readonly IConfiguration _configuration;
        protected readonly CompanyAPIService _companyService;
        protected readonly EmployeeAPIService _employeeService;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public CompaniesController(IConfiguration configuration)
        {
            _configuration = configuration;
            _companyService = new CompanyAPIService(_configuration);
            _employeeService = new EmployeeAPIService(_configuration);

        }
        // GET: CompaniesController 

        /// <summary>
        /// Get all Companies
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> GetCompanies(int id)
        {            
            List<Company> modelList =await _companyService.GetCompaniesFromAPI();
            return View(modelList);
        }


        /// <summary>
        /// Get all company employees
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetCompanyEmployees()
        {
            List<CompanyEmployees> companyEmployeesModelList = await _companyService.GetCompanyEmployeesFromAPI();
            List<Company> companiesModelList = await _companyService.GetCompaniesFromAPI();
            List<Employee> employeesModelList = await _employeeService.GetEmployeesByListFromAPI();
            
            foreach (var companyEmployee in companyEmployeesModelList)
            {
               
                var employeeModel = employeesModelList.Find(x => x.EmpNo == companyEmployee.EmpNo);
                if (employeeModel != null)
                {
                    companyEmployee.EmployeeName = employeeModel.Name;                   
                }

                var companyModel= companiesModelList.Find(x => x.Id == companyEmployee.CompanyId);
                if (companyModel != null){                    
                    companyEmployee.CompanyName = companyModel.Name;
                }
                
            }
            return View(companyEmployeesModelList);
        }

        // GET: CompaniesController/Details/5
        
        /// <summary>
        /// Createas a new Company
        /// </summary>
        /// <returns></returns>
        // GET: CompaniesController/Create
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Createas a new Company
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        // POST: CompaniesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Company company)
        {
            if (ModelState.IsValid)
            {
                await _companyService.AddCompanyFromAPI(company);

                return RedirectToAction("GetCompanies");
            }

            return View();

        }


        /// <summary>
        /// Edit a Company
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: CompaniesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            Company model = await _companyService.GetCompanyByIdFromAPI(id);
            return View(model);

        }

        /// <summary>
        /// Edit a Company
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        // POST: CompaniesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                await _companyService.UpdateCompanyFromAPI(company);

                return RedirectToAction("GetCompanies");
            }

            return View();

        }

        /// <summary>
        /// Deletes a Company
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: CompaniesController/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            Company model = await _companyService.GetCompanyByIdFromAPI((int)id);
            return View(model);
        }

        /// <summary>
        /// Deletes a Company
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: CompaniesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            await _companyService.DeleteCompanyByIdFromAPI(id);
            return RedirectToAction("GetCompanies");
        }
    }
}
