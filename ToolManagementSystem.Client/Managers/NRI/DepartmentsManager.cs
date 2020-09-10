﻿using Microsoft.AspNetCore.Mvc;
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
            try
            {
                HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName + "?name=" + filterByName);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    departments = JsonConvert.DeserializeObject<List<Department>>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
            return departments;
        }

        public async static Task<Department> GetDepartmentAsync(int id)
        {
            Department department = null;
            try
            {
                HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName + "/" + id);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    department = JsonConvert.DeserializeObject<Department>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }          
            return department;
        }

        public async static Task<Department> CreateDepartmentAsync(Department newDepartment)
        {
            Department resultDepartment = null;
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(newDepartment), Encoding.UTF8, "application/json");
                var response = await CustomHttpClient.GetClientInstance().PostAsync(apiControllerName, content);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    resultDepartment = JsonConvert.DeserializeObject<Department>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return resultDepartment;
        }

        public async static Task<System.Net.HttpStatusCode> DeleteDepartmentAsync(int id)
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

        public async static Task<Department> UpdateDepartmentAsync(Department newDepartment)
        {
            Department resultDepartment = null;
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(newDepartment), Encoding.UTF8, "application/json");
                var response = await CustomHttpClient.GetClientInstance().PutAsync(apiControllerName + "/" + newDepartment.DepartmentId, content);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    resultDepartment = JsonConvert.DeserializeObject<Department>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return resultDepartment;
        }

    }
}
