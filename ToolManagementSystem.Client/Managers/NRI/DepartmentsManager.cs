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
    public class DepartmentsManager
    {
        static string apiControllerName { get; set; } = "NRI/Departments";

        public async static Task<List<Department>> GetDepartmentsAsync(string filterByName)
        {
            List<Department> departments = null;
            HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName + "?name=" + filterByName);
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                departments = new List<Department>();
                departments = JsonConvert.DeserializeObject<List<Department>>(apiResponse);
            }
            return departments;
        }

        public async static Task<Department> GetDepartmentAsync(int id)
        {
            Department department = null;
            HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName + "/" + id);
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                department = new Department();
                department = JsonConvert.DeserializeObject<Department>(apiResponse);
            }
            return department;
        }

        public async static Task<Department> CreateDepartmentAsync(Department newDepartment)
        {
            Department resultDepartment = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(newDepartment), Encoding.UTF8, "application/json");
            var response = await CustomHttpClient.GetClientInstance().PostAsync(apiControllerName, content);
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                resultDepartment = new Department();
                resultDepartment = JsonConvert.DeserializeObject<Department>(apiResponse);
            }
            return resultDepartment;
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
            var response = await CustomHttpClient.GetClientInstance().PutAsync(apiControllerName + "/?id="+ newDepartment.DepartmentId, content);
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
