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
        public async Task<IActionResult> GetDepartments(string name)
        {
            try
            {
                List<Department> departments = new List<Department>();
                departments = await db.Department.ToListAsync();
                if (string.IsNullOrEmpty(name) == false)
                {
                    departments = departments.Where(x => x.Name == name).ToList();
                }
                return Ok(departments);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // GET api/NRI/Departments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            try
            {
                Department department = await db.Department.SingleAsync(x => x.DepartmentId == id);
                return Ok(department);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // POST api/NRI/Departments
        [HttpPost]
        public async Task<IActionResult> AddDepartment([FromBody] Department value)
        {
            try
            {
                await db.Department.AddAsync(value);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // PUT api/NRI/Departments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditDepartment(int id, [FromBody] Department value)
        {
            try
            {
                Department department = await db.Department.SingleAsync(x => x.DepartmentId == id);
                if(department != null)
                {
                    department.Name = value.Name;
                }
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // DELETE api/NRI/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            try
            {
                Department department = await db.Department.SingleAsync(x => x.DepartmentId == id);
                db.Department.Remove(department);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
    }
}
