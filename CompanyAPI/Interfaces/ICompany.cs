using CompanyAPI.Models;


namespace CompanyAPI.Interfaces
{
    public interface ICompany
    {
        // Return list of Companies
        Task<List<Company>> GetAllCompanies();
        // Return single Employee data against the Company id
        // This method will also take an ID parameter
        Task<Company> GetCompanyById(int id);
        // This method will add the Company
        /* This method will take Company object
          as a parameter and will not return anything.*/
        Task AddCompany(Company company);
        // This method will update the Company data
        /* We need to pass the id as a parameter of type integer to update the Employee record
          and will not return anything. */
        Task UpdateCompany(int id, Company company);
        // This method used to delete a particular record based on id as a parameter
        Task DeleteCompany(int id);

        Task AddCompanyEmployee(CompanyEmployees companyEmployee);
        Task UpdateCompanyEmployee(int id, CompanyEmployees companyEmployee);
        Task DeleteCompanyEmployee(int id);
        Task<List<CompanyEmployees>> GetAllCompanyEmployees();
        Task<List<CompanyEmployees>> GetCompanyEmployeesByCompanyId(int id);
    }
}
