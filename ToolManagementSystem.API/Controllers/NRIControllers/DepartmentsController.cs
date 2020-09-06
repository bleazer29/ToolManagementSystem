using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToolManagementSystem.API.Controllers.NRIControllers
{
    [Route("api/NRI/Departments")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        // GET: api/NRI/Departments
        [HttpGet]
        public IEnumerable<string> GetDepartments()
        {
            Console.WriteLine("Called GetDepartments() method");
            return new string[] { "value1", "value2" };
        }

        // GET api/NRI/Departments/5
        [HttpGet("{id}")]
        public string GetDepartment(int id)
        {
            Console.WriteLine("Called GetDepartment(id) method");
            return "value";
        }

        // POST api/NRI/Departments
        [HttpPost]
        public void AddDepartment([FromBody] string value)
        {
            Console.WriteLine("Called AddDepartment(obj) method");
        }

        // PUT api/NRI/Departments/5
        [HttpPut("{id}")]
        public void EditDepartment(int id, [FromBody] string value)
        {
            Console.WriteLine("Called EditDepartment(id, obj) method");
        }

        // DELETE api/NRI/Departments/5
        [HttpDelete("{id}")]
        public void DeleteDepartment(int id)
        {
            Console.WriteLine("Called DeleteDepartment(id) method");
        }
    }
}
