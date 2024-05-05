using Microsoft.EntityFrameworkCore;
using EmployeesAPI.Data;
using EmployeesAPI.Interfaces;
using EmployeesAPI.Models;

namespace EmployeesAPI.Services
{
    public class EmployeeService : IEmployee
    {
        private ApiDbContext _context;
        public EmployeeService()
        {
            _context = new ApiDbContext();
        }
        public async Task AddEmployee(Employee employee)
        {
            // This line will add Employee data and set the database.
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync(true);
            }
        }
        public async Task<List<Employee>> GetAllEmployees()
        {
            // This line will return list of Employees
            var employees = await _context.Employees.ToListAsync();
            return employees;
        }
        public async Task<Employee> GetEmployeeById(int id)
        {
            // This line will return the specific Employee record based on id pass as a parameter
            var employee = await _context.Employees.FindAsync(id);
            return employee;
        }
        public async Task UpdateEmployee(int id, Employee employee)
        {
            var employeeObj = await _context.Employees.FindAsync(id);
            employeeObj.Name = employee.Name;
            employeeObj.Salary = employee.Salary;
            employeeObj.EmpNo = employee.EmpNo;
            await _context.SaveChangesAsync();
        }

      
    }
}
