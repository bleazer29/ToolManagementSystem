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

        public async static Task<List<Counterparty>> GetCounterpartiesAsync(string filterByName, string filterByEDRPOU, string filterByAddress)
        {
            List<Counterparty> counterparties = null;
            try
            {
                HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName + "?name=" + filterByName+"&edrpou="+ filterByEDRPOU+ "&address=" + filterByAddress);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    counterparties = JsonConvert.DeserializeObject<List<Counterparty>>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                    counterparty = JsonConvert.DeserializeObject<Counterparty>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return counterparty;
        }

        public async static Task<System.Net.HttpStatusCode> CreateCounterpartyAsync(Counterparty newCounterparty)
        {
            
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(newCounterparty), Encoding.UTF8, "application/json");
                var response = await CustomHttpClient.GetClientInstance().PostAsync(apiControllerName, content);
                return response.StatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return System.Net.HttpStatusCode.BadRequest;
        }

        public async static Task<System.Net.HttpStatusCode> DeleteCounterpartyAsync(int id)
        {
            try
            {
                var response = await CustomHttpClient.GetClientInstance().DeleteAsync(apiControllerName + "/" + id);
                return response.StatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return System.Net.HttpStatusCode.BadRequest;
        }

        public async static Task<System.Net.HttpStatusCode> UpdateCounterpartyAsync(Counterparty newCounterparty)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(newCounterparty), Encoding.UTF8, "application/json");
                var response = await CustomHttpClient.GetClientInstance().PutAsync(apiControllerName + "/" + newCounterparty.CounterpartyId, content);
                return response.StatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return System.Net.HttpStatusCode.BadRequest;
        }

    }
}

