using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public List<Department> GetDepartments(string name)
        {
            List<Department> departments = new List<Department>();
            departments = db.Department.ToList();
            if(string.IsNullOrEmpty(name) == false)
            {
                departments = departments.Where(x => x.Name == name).ToList();
            }
            return departments;
        }

        // GET api/NRI/Departments/5
        [HttpGet("{id}")]
        public Department GetDepartment(int id)
        {
            Department department = db.Department.Single(x => x.DepartmentId == id);
            return department;
        }

        // POST api/NRI/Departments
        [HttpPost]
        public void AddDepartment([FromBody] Department value)
        {
            try
            {
                Department department = new Department();
                department = value;
                db.Department.Add(department);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // PUT api/NRI/Departments/5
        [HttpPut("{id}")]
        public void EditDepartment(int id, [FromBody] Department value)
        {
            try
            {
                Department department = db.Department.Single(x => x.DepartmentId == id);
                if(department != null)
                {
                    department.Name = value.Name;
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // DELETE api/NRI/Departments/5
        [HttpDelete("{id}")]
        public void DeleteDepartment(int id)
        {
            try
            {
                Department department = db.Department.Single(x => x.DepartmentId == id);
                db.Department.Remove(department);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
