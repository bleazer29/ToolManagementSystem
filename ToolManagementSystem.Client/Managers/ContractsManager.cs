using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ToolManagementSystem.Shared.Models;

namespace ToolManagementSystem.Client.Managers
{
    public class ContractsManager
    {
        static string apiControllerName { get; set; } = "Contracts";

        public async static Task<List<Contract>> GetContractsAsync(string filterByNumber)
        {
            List<Contract> contracts = null;
            HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName + "?number=" + filterByNumber);
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                contracts = new List<Contract>();
                contracts = JsonConvert.DeserializeObject<List<Contract>>(apiResponse);
            }
            return contracts;
        }

        public async static Task<Contract> GetContractAsync(int id)
        {
            Contract contract = null;
            HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName + "/" + id);
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                contract = new Contract();
                contract = JsonConvert.DeserializeObject<Contract>(apiResponse);
            }
            return contract;
        }

        public async static Task<Contract> CreateContractAsync(Contract newContract)
        {
            Contract resultContract = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(newContract), Encoding.UTF8, "application/json");
            var response = await CustomHttpClient.GetClientInstance().PostAsync(apiControllerName, content);
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                resultContract = new Contract();
                resultContract = JsonConvert.DeserializeObject<Contract>(apiResponse);
            }
            return resultContract;
        }

        public async static Task<System.Net.HttpStatusCode> DeleteContractAsync(int id)
        {
            var response = await CustomHttpClient.GetClientInstance().DeleteAsync(apiControllerName + "/" + id);
            return response.StatusCode;
        }

        public async static Task<Contract> UpdateContractAsync(Contract newContract)
        {
            Contract resultContract = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(newContract), Encoding.UTF8, "application/json");
            var response = await CustomHttpClient.GetClientInstance().PutAsync(apiControllerName + "/" + newContract.ContractId, content);
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                resultContract = new Contract();
                resultContract = JsonConvert.DeserializeObject<Contract>(apiResponse);
            }
            return resultContract;
        }

    }
}
