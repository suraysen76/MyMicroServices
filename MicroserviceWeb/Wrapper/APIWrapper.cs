

using MicroserviceWeb.Models;
using Newtonsoft.Json;
using System.Text;

namespace MicroserviceWeb.Wrapper
{
    public static class APIWrapper 
    {
        public static async Task<List<T>> GetRequestList<T>(string requestURl)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(requestURl);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            var modelList = JsonConvert.DeserializeObject<List<T>>(result);
            return modelList;
        }

        public static async Task<T> GetRequest<T>(string requestURl)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(requestURl);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<T>(result);
            return model;
        }




        public static async Task<string> PostRequest<T>(string requestURl,Object model )
        {
            var client = new HttpClient();

            HttpContent body = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(requestURl, body);
            response.EnsureSuccessStatusCode(); 
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        public static async Task<string> PutRequest<T>(string requestURl, Object model)
        {
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Put, requestURl)
            {
                Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")

            };
            var response = await httpClient.SendAsync(request);

            string result = await response.Content.ReadAsStringAsync();
            

            return result;
        }
        
        public static async Task<T> DeleteRequest<T>(string requestURl)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(requestURl);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<T>(result);
            return model;
        }

    }
}
