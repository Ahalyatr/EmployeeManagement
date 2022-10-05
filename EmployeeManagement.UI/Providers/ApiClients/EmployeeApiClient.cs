using EmployeeManagement.UI.Models;
using EmployeeManagement.UI.Models.Provider;
using EmployeeManagement.UI.Providers.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.UI.Providers.ApiClients
{
    public class EmployeeApiClient : IEmployeeApiClient
    {
        private readonly HttpClient _httpClient;
        
        public EmployeeApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public IEnumerable<EmployeeViewModel> GetAllEmployee()
        {
            using var response = _httpClient.GetAsync("https://localhost:5001/api/employees").Result ;
                                                                                                           
            var getAllEmployee =  JsonConvert.DeserializeObject<IEnumerable<EmployeeViewModel>>(response.Content.ReadAsStringAsync().Result);

            return getAllEmployee;                    
        }
        public EmployeeDetailedViewModel GetEmployeeById(int employeeId)
        {
            using var response = _httpClient.GetAsync("https://localhost:5001/api/employees/" + employeeId).Result;

            var getEmployeeById = JsonConvert.DeserializeObject<EmployeeDetailedViewModel> (response.Content.ReadAsStringAsync().Result);

            return getEmployeeById;
        }

        public bool InsertEmployee(EmployeeDetailedViewModel employee)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");

            var response = _httpClient.PostAsync("https://localhost:5001/api/employeeinsert", stringContent).Result;

            return true;
        }

        public bool EditEmployee(EmployeeDetailedViewModel employee)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");

            var response =_httpClient.PutAsync("https://localhost:5001/api/employeeedit", stringContent).Result;

            return true;           
        }

        public bool DeleteEmployee(int employeeId)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(employeeId));

            var response = _httpClient.DeleteAsync("https://localhost:5001/api/employeedelete/"+employeeId).Result;

            return true;
        }

    }
}
