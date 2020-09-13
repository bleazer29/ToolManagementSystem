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
    public class WellsManager
    {
        static string apiControllerName { get; set; } = "NRI/Wells";

        public async static Task<List<Well>> GetWellsAsync(string filterByName, string filterByAddress, string filterByWellNumber, string sortField, bool isAscendingSort)
        {
            List<Well> wells = null;
            try
            {
                HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName + "?name=" + filterByName + "&address=" + filterByAddress + "&wellNumber="+ filterByWellNumber);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    wells = JsonConvert.DeserializeObject<List<Well>>(apiResponse);
                    if (isAscendingSort)
                    {
                        if (sortField == "Name")
                        {
                            wells = wells.OrderBy(x => x.Name).ToList();
                        }
                        else if (sortField == "Address")
                        {
                            wells = wells.OrderBy(x => x.Address).ToList();
                        }
                        else if (sortField == "WellNumber")
                        {
                            wells = wells.OrderBy(x => x.WellNumber).ToList();
                        }
                    }
                    else
                    {
                        if (sortField == "Name")
                        {
                            wells = wells.OrderByDescending(x => x.Name).ToList();
                        }
                        else if (sortField == "Address")
                        {
                            wells = wells.OrderByDescending(x => x.Address).ToList();
                        }
                        else if (sortField == "WellNumber")
                        {
                            wells = wells.OrderByDescending(x => x.WellNumber).ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return wells;
        }

        public async static Task<Well> GetWellAsync(int id)
        {
            Well well = null;
            try
            {
                HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName + "/" + id);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    well = JsonConvert.DeserializeObject<Well>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return well;
        }

        public async static Task<System.Net.HttpStatusCode> CreateWellAsync(Well newWell)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(newWell), Encoding.UTF8, "application/json");
                var response = await CustomHttpClient.GetClientInstance().PostAsync(apiControllerName, content);
                return response.StatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return System.Net.HttpStatusCode.BadRequest;
        }

        public async static Task<System.Net.HttpStatusCode> DeleteWellAsync(int id)
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

        public async static Task<System.Net.HttpStatusCode> UpdateWellAsync(Well newWell)
        {

            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(newWell), Encoding.UTF8, "application/json");
                var response = await CustomHttpClient.GetClientInstance().PutAsync(apiControllerName + "/" + newWell.WellId, content);
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
