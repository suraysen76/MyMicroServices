
using MicroserviceWeb.Models;
using MicroserviceWeb.APIServices;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceWeb.Controllers
{
    public class EmployeesController : Controller
    {
        private List<Employee> modelEmployees ;
        protected readonly IConfiguration _configuration;
        protected readonly EmployeeAPIService _employeeService;
        protected readonly CompanyAPIService _companyService;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public EmployeesController(IConfiguration configuration)
        {
            _configuration = configuration;
            _employeeService = new EmployeeAPIService(_configuration);
            _companyService = new CompanyAPIService(_configuration);

        }
        /// <summary>
        /// Get a;; employees
        /// </summary>
        /// <returns></returns>
        // GET: EmployeesController 
        public async Task<ActionResult> GetEmployees()
        {            
            List<Employee> modelList =await _employeeService.GetEmployeesByListFromAPI();
            return View(modelList);
        }
       
        /// <summary>
        /// Create a new employee
        /// </summary>
        /// <returns></returns>
        // GET: CompaniesController/Create
        public async Task<ActionResult> Create()
        {
            var compaies = await _employeeService.GetCompanyListItems();
            ViewBag.CompanyList =compaies;

            return View();
        }

        /// <summary>
        /// Create a new employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        // POST: CompaniesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Employee employee)
        {
            var companyemployee = new CompanyEmployees()
            {
                EmployeeName = employee.Name,
                EmpNo = employee.EmpNo,
                CompanyName = employee.CompanyName,
                CompanyId = employee.CompanyId

            };
            if (ModelState.IsValid)
            {
                await _employeeService.AddEmployeeFromAPI(employee);
                await _companyService.AddCompanyEmployeeFromAPI(companyemployee);
                return RedirectToAction("GetEmployees");
            }
            var compaies = await _employeeService.GetCompanyListItems();
            ViewBag.CompanyList =compaies;

            return View();

        }

        /// <summary>
        /// Edit a employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: CompaniesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Employee model = await _employeeService.GetEmployeeByIdFromAPI(id);
            return View(model);
        }

        /// <summary>
        /// Edit a employee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        // POST: CompaniesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.UpdateEmployeeFromAPI(employee);
                return RedirectToAction("GetEmployees");
            }

            return View();
        }

        /// <summary>
        /// Delete a employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: CompaniesController/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            Employee model = await _employeeService.GetEmployeeByIdFromAPI((int)id);
            return View(model);     

        }

        /// <summary>
        /// Delete a employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: CompaniesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            await _employeeService.DeleteEmployeeByIdFromAPI(id);
            return RedirectToAction("GetEmployees");
        }
    }
}
