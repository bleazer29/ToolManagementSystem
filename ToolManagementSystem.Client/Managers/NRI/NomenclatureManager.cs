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
    public class NomenclatureManager
    {
        static string apiControllerName { get; set; } = "NRI/Nomenclature";

        public async static Task<List<Nomenclature>> GetNomenclaturesAsync(string filterByName, string filterByVendorCode, string sortField, bool isAscendingSort)
        {
            List<Nomenclature> nomenclatures = null;
            try
            {
                HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName + "?name=" + filterByName + "&vendorCode=" + filterByVendorCode);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    nomenclatures = JsonConvert.DeserializeObject<List<Nomenclature>>(apiResponse);
                    if (isAscendingSort)
                    {
                        if (sortField == "Name")
                        {
                            nomenclatures = nomenclatures.OrderBy(x => x.Name).ToList();
                        }
                        else if (sortField == "VendorCode")
                        {
                            nomenclatures = nomenclatures.OrderBy(x => x.VendorCode).ToList();
                        }
                        else if (sortField == "OperatingTime")
                        {
                            nomenclatures = nomenclatures.OrderBy(x => x.MaxOperatingTime).ToList();
                        }
                    }
                    else
                    {
                        if (sortField == "Name")
                        {
                            nomenclatures = nomenclatures.OrderByDescending(x => x.Name).ToList();
                        }
                        else if (sortField == "VendorCode")
                        {
                            nomenclatures = nomenclatures.OrderByDescending(x => x.VendorCode).ToList();
                        }
                        else if (sortField == "OperatingTime")
                        {
                            nomenclatures = nomenclatures.OrderByDescending(x => x.MaxOperatingTime).ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return nomenclatures;
        }

        public async static Task<Nomenclature> GetNomenclatureAsync(int id)
        {
            Nomenclature nomenclature = null;
            try
            {
                HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName + "/" + id);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    nomenclature = JsonConvert.DeserializeObject<Nomenclature>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return nomenclature;
        }

        public async static Task<System.Net.HttpStatusCode> CreateNomenclatureAsync(Nomenclature newNomenclature)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(newNomenclature), Encoding.UTF8, "application/json");
                var response = await CustomHttpClient.GetClientInstance().PostAsync(apiControllerName, content);
                return response.StatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return System.Net.HttpStatusCode.BadRequest;
        }

        public async static Task<System.Net.HttpStatusCode> DeleteNomenclatureAsync(int id)
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

        public async static Task<System.Net.HttpStatusCode> UpdateNomenclatureAsync(Nomenclature newNomenclature)
        {

            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(newNomenclature), Encoding.UTF8, "application/json");
                var response = await CustomHttpClient.GetClientInstance().PutAsync(apiControllerName + "/" + newNomenclature.NomenclatureId, content);
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
