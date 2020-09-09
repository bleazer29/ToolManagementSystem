﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolManagementSystem.Shared.Models;

namespace ToolManagementSystem.API.Controllers.NRIControllers
{
    [Route("api/NRI/Departments")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly TMSdbContext db;
        
        public DepartmentsController(TMSdbContext context)
        {
            db = context;
        }

        // GET: api/NRI/Departments
        [HttpGet]
        public async Task<List<Department>> GetDepartments(string name)
        {
            List<Department> departments = new List<Department>();
            departments = await db.Department.ToListAsync();
            if(string.IsNullOrEmpty(name) == false)
            {
                departments = departments.Where(x => x.Name == name).ToList();
            }
            return departments;
        }

        // GET api/NRI/Departments/5
        [HttpGet("{id}")]
        public async Task<Department> GetDepartment(int id)
        {
            Department department = await db.Department.SingleAsync(x => x.DepartmentId == id);
            return department;
        }

        // POST api/NRI/Departments
        [HttpPost]
        public async Task<Department> AddDepartment([FromBody] Department value)
        {
            try
            {
                await db.Department.AddAsync(value);
                await db.SaveChangesAsync();
                return await db.Department.SingleAsync(x => x.Name == value.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new Department() { DepartmentId = -1 };
        }

        // PUT api/NRI/Departments/5
        [HttpPut("{id}")]
        public async Task<Department> EditDepartment(int id, [FromBody] Department value)
        {
            try
            {
                Department department = await db.Department.SingleAsync(x => x.DepartmentId == id);
                if(department != null)
                {
                    department.Name = value.Name;
                }
                await db.SaveChangesAsync();
                return department;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new Department() { DepartmentId = -1 };
        }

        // DELETE api/NRI/Departments/5
        [HttpDelete("{id}")]
        public async Task DeleteDepartment(int id)
        {
            try
            {
                Department department = await db.Department.SingleAsync(x => x.DepartmentId == id);
                db.Department.Remove(department);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
