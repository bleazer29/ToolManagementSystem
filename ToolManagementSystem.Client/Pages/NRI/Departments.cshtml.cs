﻿using System;
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

        public async Task<IActionResult> OnGet()
        {
            Departments = await DepartmentsManager.GetDepartmentsAsync(FilterByName, "Name", true);
            Departments = Departments.OrderBy(x => x.Name).ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostDepartment()
        {
            HttpStatusCode temp = await DepartmentsManager.CreateDepartmentAsync(NewDepartment);
            if(temp != HttpStatusCode.OK)
            {
                //do something
               
            }
            return RedirectToPage("Departments");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            HttpStatusCode temp = await DepartmentsManager.DeleteDepartmentAsync(DeleteDepartmentId);
            if (temp != HttpStatusCode.OK)
            {
                //do something
            }
            return RedirectToPage("Departments");
        }

        public async Task<IActionResult> OnPostUpdate()
        {
            HttpStatusCode temp = await DepartmentsManager.UpdateDepartmentAsync(EditDepartment);
            if (temp != HttpStatusCode.OK)
            {
                //do something
            }
            return RedirectToPage("Departments");
        }


    }
}