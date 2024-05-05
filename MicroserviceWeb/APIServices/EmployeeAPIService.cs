using MicroserviceWeb.Models;
using MicroserviceWeb.Wrapper;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MicroserviceWeb.APIServices
{
    public class EmployeeAPIService
    {
        protected readonly IConfiguration _configuration;

        public async Task<List<Company>> GetCompaniesFromAPI()
        {
            string baseURL = _configuration.GetValue<string>("CompanyAPIService:BaseURL");
            string requestURl = baseURL + "api/Companies";
            List<Company> modelList = await APIWrapper.GetRequestList<Company>(requestURl);

            return modelList;
        }

        public async Task<IEnumerable<SelectListItem>> GetCompanyListItems()
        {
            List<Company> companies = await GetCompaniesFromAPI();

            var selectList = new List<SelectListItem>();

            var companiesList = companies
               .Select(x =>
                       new SelectListItem
                       {
                           Value = x.Id.ToString(),
                           Text = x.Name
                       }) ;

            return new SelectList(companiesList, "Value", "Text");
            
        }

        public EmployeeAPIService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task< List<Employee>> GetEmployeesByListFromAPI()
        {
            string baseURL = _configuration.GetValue<string>("EmployeeAPIService:BaseURL");
            string requestURl = baseURL + "api/Employees";
            List<Employee> modelList = await APIWrapper.GetRequestList<Employee>(requestURl);

            return modelList;
        }
        
        public async Task<List<Employee>> GetEmployeesFromAPI()
        {
            string baseURL = _configuration.GetValue<string>("CompanyAPIService:BaseURL");
            string requestURl = baseURL + "api/Employees";
            List<Employee> modelList = await APIWrapper.GetRequestList<Employee>(requestURl);

            return modelList;
        }
        public async Task<string> AddEmployeeFromAPI(Employee employee)
        {
            string baseURL = _configuration.GetValue<string>("EmployeeAPIService:BaseURL");
            string requestURl = baseURL + "api/Employees";

            var response = await APIWrapper.PostRequest<Employee>(requestURl, employee);

            return response;
        }
        public async Task<Employee> GetEmployeeByIdFromAPI(int id)
        {
            string baseURL = _configuration.GetValue<string>("EmployeeAPIService:BaseURL");
            string requestURl = baseURL + "api/Employees/+" + id;
            Employee model = await APIWrapper.GetRequest<Employee>(requestURl);

            return model;
        }
        
        public async Task<string> DeleteEmployeeByIdFromAPI(int? id)
        {
            string baseURL = _configuration.GetValue<string>("EmployeeAPIService:BaseURL");
            string requestURl = baseURL + "api/Employees/+" + id;
            var response = await APIWrapper.DeleteRequest<string>(requestURl);

            return response;
        }

        public async Task<string> UpdateEmployeeFromAPI(Employee employee)
        {
            int id = employee.Id;
            string baseURL = _configuration.GetValue<string>("EmployeeAPIService:BaseURL");
            string requestURl = baseURL + "api/Employees/" + id;

            var response = await APIWrapper.PutRequest<Employee>(requestURl, employee);

            return response;
        }
        


    }
}
