using EmployeesAPI.Models;


namespace EmployeesAPI.Interfaces
{
    public interface IEmployee
    {
        // Return list of Employees
        Task<List<Employee>> GetAllEmployees();
        // Return single Employee data against the Employee id
        // This method will also take an ID parameter
        Task<Employee> GetEmployeeById(int id);
        // This method will add the Employee
        /* This method will take Employee object
          as a parameter and will not return anything.*/
        Task AddEmployee(Employee employee);
        // This method will update the Employee data
        /* We need to pass the id as a parameter of type integer to update the Employee record
          and will not return anything. */
        Task UpdateEmployee(int id, Employee employee);
        // This method used to delete a particular record based on id as a parameter
        Task DeleteEmployee(int id);
    }
}
