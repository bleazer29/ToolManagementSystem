using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolManagementSystem.Client.Managers.NRI;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using ToolManagementSystem.Shared.Models;
using System.Text;

namespace ToolManagementSystem.Client.Managers.NRI
{
    public class SpecificationsManager
    {
        static string apiControllerName { get; set; } = "NRI/Specifications";

        public async static Task<List<Specification>> GetSpecificationsAsync(string filterByName, string sortField, bool isAscendingSort)
        {
            List<Specification> specifications = null;
            try
            {
                HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName + "?name=" + filterByName);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    specifications = JsonConvert.DeserializeObject<List<Specification>>(apiResponse);
                    if (isAscendingSort)
                    {
                        if (sortField == "Name")
                        {
                            specifications = specifications.OrderBy(x => x.Name).ToList();
                        }
                    }
                    else
                    {
                        if (sortField == "Name")
                        {
                            specifications = specifications.OrderByDescending(x => x.Name).ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return specifications;
        }

        public async static Task<Specification> GetSpecificationAsync(int id)
        {
            Specification specification = null;
            try
            {
                HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName + "/" + id);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    specification = JsonConvert.DeserializeObject<Specification>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return specification;
        }

        public async static Task<System.Net.HttpStatusCode> CreateSpecificationAsync(Specification newSpecification)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(newSpecification), Encoding.UTF8, "application/json");
                var response = await CustomHttpClient.GetClientInstance().PostAsync(apiControllerName, content);
                return response.StatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return System.Net.HttpStatusCode.BadRequest;
        }

        public async static Task<System.Net.HttpStatusCode> DeleteSpecificationAsync(int id)
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

        public async static Task<System.Net.HttpStatusCode> UpdateSpecificationAsync(Specification newSpecification)
        {

            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(newSpecification), Encoding.UTF8, "application/json");
                var response = await CustomHttpClient.GetClientInstance().PutAsync(apiControllerName + "/" + newSpecification.SpecificationId, content);
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
