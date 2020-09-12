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
    public class ToolStatusesManager
    {
        static string apiControllerName { get; set; } = "NRI/Statuses";

        public async static Task<List<ToolStatus>> GetToolStatusesAsync(string filterByName, string sortField, bool isAscendingSort)
        {
            List<ToolStatus> toolStatuses = null;
            try
            {
                HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName + "?name=" + filterByName);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    toolStatuses = JsonConvert.DeserializeObject<List<ToolStatus>>(apiResponse);
                    if (isAscendingSort)
                    {
                        if (sortField == "Name")
                        {
                            toolStatuses = toolStatuses.OrderBy(x => x.Name).ToList();
                        }                       
                    }
                    else
                    {
                        if (sortField == "Name")
                        {
                            toolStatuses = toolStatuses.OrderByDescending(x => x.Name).ToList();
                        }                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return toolStatuses;
        }

        public async static Task<ToolStatus> GetToolStatusAsync(int id)
        {
            ToolStatus toolStatus = null;
            try
            {
                HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName + "/" + id);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    toolStatus = JsonConvert.DeserializeObject<ToolStatus>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return toolStatus;
        }

        public async static Task<System.Net.HttpStatusCode> CreateToolStatusAsync(ToolStatus newToolStatus)
        {

            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(newToolStatus), Encoding.UTF8, "application/json");
                var response = await CustomHttpClient.GetClientInstance().PostAsync(apiControllerName, content);
                return response.StatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return System.Net.HttpStatusCode.BadRequest;
        }

        public async static Task<System.Net.HttpStatusCode> DeleteToolStatusAsync(int id)
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

        public async static Task<System.Net.HttpStatusCode> UpdateToolStatusAsync(ToolStatus newToolStatus)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(newToolStatus), Encoding.UTF8, "application/json");
                var response = await CustomHttpClient.GetClientInstance().PutAsync(apiControllerName + "/" + newToolStatus.ToolStatusId, content);
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
