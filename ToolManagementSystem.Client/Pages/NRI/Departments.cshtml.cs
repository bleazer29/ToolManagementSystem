using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToolManagementSystem.Shared.Models;
using ToolManagementSystem.API;
using ToolManagementSystem.Client;
using ToolManagementSystem.Client.Requests;
using System.Net.Http;
using Newtonsoft.Json;

namespace ToolManagementSystem.Client.Pages.NRI
{
    public class DepartmentsModel: PageModel
    {
        public List<Department> Departments { get; set; } = new List<Department>();

        [BindProperty]
        public Department NewDepartment { get; set; } = new Department();

        

        public void OnGet()
        {

            Departments = GetDepartmentsAsync().Result;

        }

       


        //async Task<List<Department>> PostDepartment()
        //{
        //    List<Department> departments = null;
        //    HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        string apiResponse = await response.Content.ReadAsStringAsync();
        //        departments = new List<Department>();
        //        departments = JsonConvert.DeserializeObject<List<Department>>(apiResponse);
        //    }
        //    return departments;
        //}


    }
}