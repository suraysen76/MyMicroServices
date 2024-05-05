using MicroserviceWeb.Models;
using MicroserviceWeb.Wrapper;
using Microsoft.Extensions.Configuration;

namespace MicroserviceWeb.APIServices
{    
    public class CompanyAPIService
    {
        protected readonly IConfiguration _configuration;
        public CompanyAPIService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task< List<Company>> GetCompaniesFromAPI()
        {
            string baseURL = _configuration.GetValue<string>("CompanyAPIService:BaseURL");
            string requestURl = baseURL + "api/Companies";
            List<Company> modelList = await APIWrapper.GetRequestList<Company>(requestURl);

            return modelList;
        }

        public async Task<List<CompanyEmployees>> GetCompanyEmployeesFromAPI()
        {
            string baseURL = _configuration.GetValue<string>("CompanyAPIService:BaseURL");
            string requestURl = baseURL + "api/CompanyEmployees";
            List<CompanyEmployees> modelList = await APIWrapper.GetRequestList<CompanyEmployees>(requestURl);

            return modelList;
        }

        public async Task<string> AddCompanyFromAPI(Company company)
        {
            string baseURL = _configuration.GetValue<string>("CompanyAPIService:BaseURL");
            string requestURl = baseURL + "api/Companies";

            var response = await APIWrapper.PostRequest<Company>(requestURl,company);

            return response;
        }

        public async Task<string> AddCompanyEmployeeFromAPI(CompanyEmployees companyEmployee)
        {
            string baseURL = _configuration.GetValue<string>("CompanyAPIService:BaseURL");
            string requestURl = baseURL + "api/CompanyEmployees";

            var response = await APIWrapper.PostRequest<CompanyEmployees>(requestURl, companyEmployee);

            return response;
        }

        public async Task<Company> GetCompanyByIdFromAPI(int id)
        {
            string baseURL = _configuration.GetValue<string>("CompanyAPIService:BaseURL");
            string requestURl = baseURL + "api/Companies/+"+id;
            Company model = await APIWrapper.GetRequest<Company>(requestURl);

            return model;
        }

        public async Task<string> DeleteCompanyByIdFromAPI(int? id)
        {
            string baseURL = _configuration.GetValue<string>("CompanyAPIService:BaseURL");
            string requestURl = baseURL + "api/Companies/+" + id;
            var response = await APIWrapper.DeleteRequest<string>(requestURl);

            return response;
        }
        public async Task<string> UpdateCompanyFromAPI(Company company)
        {
            int id = company.Id;
            string baseURL = _configuration.GetValue<string>("CompanyAPIService:BaseURL");
            string requestURl = baseURL + "api/Companies/" + id;

            var response = await APIWrapper.PutRequest<Company>(requestURl, company);

            return response;
        }
        
    }
}
