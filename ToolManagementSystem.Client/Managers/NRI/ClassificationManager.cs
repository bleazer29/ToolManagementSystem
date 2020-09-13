using Microsoft.AspNetCore.Mvc;
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
    public class ClassificationManager
    {
        static string apiControllerName { get; set; } = "NRI/Classification";

        public async static Task<List<ToolClassification>> GetClassificationsAsync(string filterByName, string sortField, bool isAscendingSort)
        {
            List<ToolClassification> classifications = null;
            try
            {
                HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName + "?name=" + filterByName);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    classifications = JsonConvert.DeserializeObject<List<ToolClassification>>(apiResponse);
                    if (isAscendingSort)
                    {
                        if (sortField == "Name")
                        {
                            classifications = classifications.OrderBy(x => x.Name).ToList();
                        }
                    }
                    else
                    {
                        if (sortField == "Name")
                        {
                            classifications = classifications.OrderByDescending(x => x.Name).ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return classifications;
        }

        public async static Task<ToolClassification> GetClassificationAsync(int id)
        {
            ToolClassification classification = null;
            try
            {
                HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName + "/" + id);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    classification = JsonConvert.DeserializeObject<ToolClassification>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return classification;
        }

        public async static Task<System.Net.HttpStatusCode> CreateClassificationAsync(ToolClassification newToolClassification)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(newToolClassification), Encoding.UTF8, "application/json");
                var response = await CustomHttpClient.GetClientInstance().PostAsync(apiControllerName, content);
                return response.StatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return System.Net.HttpStatusCode.BadRequest;
        }

        public async static Task<System.Net.HttpStatusCode> DeleteClassificationAsync(int id)
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

        public async static Task<System.Net.HttpStatusCode> UpdateClassificationAsync(ToolClassification newToolClassification)
        {

            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(newToolClassification), Encoding.UTF8, "application/json");
                var response = await CustomHttpClient.GetClientInstance().PutAsync(apiControllerName + "/" + newToolClassification.ToolClassificationId, content);
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
