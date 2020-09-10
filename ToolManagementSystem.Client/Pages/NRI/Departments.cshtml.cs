using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToolManagementSystem.Shared.Models;
using ToolManagementSystem.API;
using ToolManagementSystem.Client;
using ToolManagementSystem.Client.Managers.NRI;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;

namespace ToolManagementSystem.Client.Pages.NRI
{
    public class DepartmentsModel: PageModel
    {
        public List<Department> Departments { get; set; } = new List<Department>();

        [BindProperty]
        public Department NewDepartment { get; set; } = new Department();

        [BindProperty]
        public Department EditDepartment { get; set; } = new Department();

        [BindProperty]
        public string FilterByName { get; set; }

        [BindProperty]
        public int DeleteDepartmentId { get; set; }

        public IActionResult OnGet()
        {
            Departments = DepartmentsManager.GetDepartmentsAsync(FilterByName).Result;
            return Page();
        }

        public void OnGetDepartment(int id)
        {
            EditDepartment = DepartmentsManager.GetDepartmentAsync(id).Result;
            if (EditDepartment.DepartmentId == -1)
            {
                //do something
            }
        }

        public IActionResult OnPostDepartment()
        {
            Department temp = DepartmentsManager.CreateDepartmentAsync(NewDepartment).Result;
            if(temp != null)
            {
                DepartmentsManager.CreateDepartmentAsync(temp);
            }
            return OnGet();
        }

        public IActionResult OnPostDelete()
        {
            HttpStatusCode temp = DepartmentsManager.DeleteDepartmentAsync(DeleteDepartmentId).Result;
            if (temp != HttpStatusCode.OK)
            {
                //do something
            }
            return OnGet();
        }

        public IActionResult OnPostUpdate()
        {
            Department temp = DepartmentsManager.UpdateDepartmentAsync(EditDepartment).Result;
            if(temp != null)
            {
                if (temp.DepartmentId == -1)
                {
                    //do something
                }
            }
            return OnGet();
        }


    }
}