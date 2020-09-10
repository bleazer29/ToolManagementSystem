using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ToolManagementSystem.Shared.Models;

namespace ToolManagementSystem.Client.Managers.NRI
{
    public class CounterpartiesManager
    {
        static string apiControllerName { get; set; } = "NRI/Counterparties";

        public async static Task<List<Counterparty>> GetCounterpartiesAsync(string filterByName, string filterByAddress, string filterbyEDRPOU)
        {
            List<Counterparty> counterparties = null;
            try
            {
                HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName + "?name=" + filterByName + "&edrpou=" + filterbyEDRPOU);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    counterparties = new List<Counterparty>();
                    counterparties = JsonConvert.DeserializeObject<List<Counterparty>>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return counterparties;
        }

        public async static Task<Counterparty> GetCounterpartyAsync(int id)
        {
            Counterparty counterparty = null;
            try
            {
                HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName + "/" + id);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    counterparty = new Counterparty();
                    counterparty = JsonConvert.DeserializeObject<Counterparty>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return counterparty;
        }

        public async static Task<Counterparty> CreateCreateAsync(Counterparty newCounterparty)
        {
            Counterparty resultCounterparty = null;
           
            StringContent content = new StringContent(JsonConvert.SerializeObject(newCounterparty), Encoding.UTF8, "application/json");
            var response = await CustomHttpClient.GetClientInstance().PostAsync(apiControllerName, content);
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                resultCounterparty = new Counterparty();
                resultCounterparty = JsonConvert.DeserializeObject<Counterparty>(apiResponse);
            }
            return resultCounterparty;
        }

        public async static Task<System.Net.HttpStatusCode> DeleteDepartmentAsync(int id)
        {
            var response = await CustomHttpClient.GetClientInstance().DeleteAsync(apiControllerName + "/" + id);
            return response.StatusCode;
        }

        public async static Task<Department> UpdateDepartmentAsync(Department newDepartment)
        {
            Department resultDepartment = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(newDepartment), Encoding.UTF8, "application/json");
            var response = await CustomHttpClient.GetClientInstance().PutAsync(apiControllerName + "/?id=" + newDepartment.DepartmentId, content);
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                resultDepartment = new Department();
                resultDepartment = JsonConvert.DeserializeObject<Department>(apiResponse);
            }
            return resultDepartment;
        }
    }
}
