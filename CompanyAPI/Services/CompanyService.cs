using Microsoft.EntityFrameworkCore;
using CompanyAPI.Data;
using CompanyAPI.Interfaces;
using CompanyAPI.Models;

namespace CompanyAPI.Services
{
    public class CompanyService : ICompany
    {
        private ApiDbContext _context;
        public CompanyService()
        {
            _context = new ApiDbContext();
        }
        public async Task AddCompany(Company company)
        {
            // This line will add Employee data and set the database.
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company != null)
            {
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync(true);
            }
        }
        public async Task<List<Company>> GetAllCompanies()
        {
            // This line will return list of companies
            var companies = await _context.Companies.ToListAsync();
            return companies;
        }
        public async Task<Company> GetCompanyById(int id)
        {
            // This line will return the specific company record based on id pass as a parameter
            var company = await _context.Companies.FindAsync(id);
            return company;
        }
        public async Task UpdateCompany(int id, Company company)
        {
            var companyObj = await _context.Companies.FindAsync(id);
            companyObj.Name = company.Name;
            companyObj.Location = company.Location;
            await _context.SaveChangesAsync();
        }

        public async Task AddCompanyEmployee(CompanyEmployees companyEmployee)
        {
            await _context.CompanyEmployees.AddAsync(companyEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCompanyEmployee(int id)
        {
            var companyEmployee = await _context.CompanyEmployees.FindAsync(id);
            if (companyEmployee != null)
            {
                _context.CompanyEmployees.Remove(companyEmployee);
                await _context.SaveChangesAsync(true);
            }
        }

        public async Task<List<CompanyEmployees>> GetAllCompanyEmployees()
        {
            var companyEmployees = await _context.CompanyEmployees.ToListAsync();
            return companyEmployees;
        }

      
        public async Task UpdateCompanyEmployee(int id, CompanyEmployees companyEmployee)
        {
            var companyEmployeeObj = await _context.CompanyEmployees.FindAsync(id);
            companyEmployeeObj.EmpNo = companyEmployee.EmpNo;
            companyEmployeeObj.CompanyID = companyEmployee.CompanyID;
            await _context.SaveChangesAsync();
        }

        public async Task<List<CompanyEmployees>> GetCompanyEmployeesByCompanyId(int id)
        {
            var companyEmployees = await _context.CompanyEmployees.Where(X => X.CompanyID == id).ToListAsync();
            return companyEmployees;
        }
    }
}
