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
    public class UnitsManager
    {
        static string apiControllerName { get; set; } = "NRI/Specifications/Units";

        public async static Task<List<Unit>> GetUnitsAsync(/*string filterByName,*/ string sortField, bool isAscendingSort)
        {
            List<Unit> units = null;
            try
            {
                HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName /*+ "?name=" + filterByName*/);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    units = JsonConvert.DeserializeObject<List<Unit>>(apiResponse);
                    if (isAscendingSort)
                    {
                        if (sortField == "Name")
                        {
                            units = units.OrderBy(x => x.Name).ToList();
                        }
                    }
                    else
                    {
                        if (sortField == "Name")
                        {
                            units = units.OrderByDescending(x => x.Name).ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return units;
        }

        public async static Task<Unit> GetUnitAsync(int id)
        {
            Unit unit = null;
            try
            {
                HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName + "/" + id);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    unit = JsonConvert.DeserializeObject<Unit>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return unit;
        }

        public async static Task<System.Net.HttpStatusCode> CreateUnitAsync(Unit newUnit)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(newUnit), Encoding.UTF8, "application/json");
                var response = await CustomHttpClient.GetClientInstance().PostAsync(apiControllerName, content);
                return response.StatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return System.Net.HttpStatusCode.BadRequest;
        }

        public async static Task<System.Net.HttpStatusCode> DeleteUnitAsync(int id)
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

        public async static Task<System.Net.HttpStatusCode> UpdateUnitAsync(Unit newUnit)
        {

            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(newUnit), Encoding.UTF8, "application/json");
                var response = await CustomHttpClient.GetClientInstance().PutAsync(apiControllerName + "/" + newUnit.UnitId, content);
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
