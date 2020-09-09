using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToolManagementSystem.Shared.Models;
using ToolManagementSystem.API;
using ToolManagementSystem.Client;
using System.Net.Http;
using Newtonsoft.Json;

namespace ToolManagmentSystem.Client.Pages.NRI
{
    public class DepartmentsModel : PageModel
    {
        public List<Department> Departments { get; set; } = new List<Department>();

        [BindProperty]
        public Department NewDepartment { get; set; } = new Department();

        public string apiControllerName { get; set; } = "NRI/Departments/";

        public async void OnGet()
        {
            
            HttpResponseMessage response = await CustomHttpClient. GetClientInstance().GetAsync(apiControllerName);
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                Departments = new List<Department>();
                Departments = JsonConvert.DeserializeObject<List<Department>>(apiResponse);
            }

        }

        async Task<List<Department>> GetDepartmentsAsync()
        {
            List<Department> departments = null;
            HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName);
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                departments = new List<Department>();
                departments = JsonConvert.DeserializeObject<List<Department>>(apiResponse);
            }
            return departments;
        }

        

    }
}