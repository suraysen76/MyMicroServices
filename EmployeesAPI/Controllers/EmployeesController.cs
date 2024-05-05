


using Microsoft.AspNetCore.Mvc;
using EmployeesAPI.Interfaces;
using EmployeesAPI.Models;
using EmployeesAPI.Services;

namespace EmployeesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployee _employeeService;

        public EmployeesController(IEmployee employeeService)
        {
            _employeeService = employeeService;
        }
        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            var employees = await _employeeService.GetAllEmployees();
            return employees;
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<Employee> Get(int id)
        {
            return await _employeeService.GetEmployeeById(id);
        }

        // POST api/<EmployeeesController>
        [HttpPost]
        public async Task Post([FromBody] Employee employee)
        {
            await _employeeService.AddEmployee(employee);
        }

        // PUT api/<EmployeeesController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Employee employee)
        {
            await _employeeService.UpdateEmployee(id, employee);
        }

        // DELETE api/<EmployeeesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _employeeService.DeleteEmployee(id);
        }
    }
}
