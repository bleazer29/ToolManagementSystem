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

        public async static Task<List<Contract>> GetContractsAsync(string filterByName, DateTime filterByDateStart, DateTime filterByDateEnd, string filterByCounterpartyName, string sortField, bool isAscendingSort)
        {
            List<Contract> contracts = null;
            try
            {
                HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName + "/" + filterByDateStart.ToString("yyyy-MM-dd")+"/" + filterByDateEnd.ToString("yyyy-MM-dd") + "?name="+ filterByName + "&counterparty=" + filterByCounterpartyName);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    contracts = JsonConvert.DeserializeObject<List<Contract>>(apiResponse);
                    if (isAscendingSort)
                    {
                        if (sortField == "Name")
                        {
                            contracts = contracts.OrderBy(x => x.Name).ToList();
                        }
                        else if (sortField == "DateStart")
                        {
                            contracts = contracts.OrderBy(x => x.DateStart).ToList();
                        }
                        else if (sortField == "DateEnd")
                        {
                            contracts = contracts.OrderBy(x => x.DateEnd).ToList();
                        }
                        else if (sortField == "Counterparty")
                        {
                            contracts = contracts.OrderBy(x => x.Counterparty == null ? "" : x.Counterparty.Name).ToList();
                        }
                    }
                    else
                    {
                        if (sortField == "Name")
                        {
                            contracts = contracts.OrderByDescending(x => x.Name).ToList();
                        }
                        else if (sortField == "DateStart")
                        {
                            contracts = contracts.OrderByDescending(x => x.DateStart).ToList();
                        }
                        else if (sortField == "DateEnd")
                        {
                            contracts = contracts.OrderByDescending(x => x.DateEnd).ToList();
                        }
                        else if (sortField == "Counterparty")
                        {
                            contracts = contracts.OrderByDescending(x => x.Counterparty == null ? "" : x.Counterparty.Name).ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return contracts;
        }

        public async static Task<Contract> GetContractAsync(int id)
        {
            Contract contract = null;
            try
            {
                HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName + "/" + id);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    contract = JsonConvert.DeserializeObject<Contract>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return contract;
        }

        public async static Task<System.Net.HttpStatusCode> CreateContractAsync(Contract newContract)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(newContract), Encoding.UTF8, "application/json");
                var response = await CustomHttpClient.GetClientInstance().PostAsync(apiControllerName, content);
                return response.StatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return System.Net.HttpStatusCode.BadRequest;
        }

        public async static Task<System.Net.HttpStatusCode> DeleteContractAsync(int id)
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

        public async static Task<System.Net.HttpStatusCode> UpdateContractAsync(Contract newContract)
        {

            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(newContract), Encoding.UTF8, "application/json");
                var response = await CustomHttpClient.GetClientInstance().PutAsync(apiControllerName + "/" + newContract.ContractId, content);
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
