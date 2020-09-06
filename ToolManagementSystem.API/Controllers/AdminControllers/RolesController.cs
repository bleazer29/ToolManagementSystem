using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToolManagementSystem.API.Controllers.AdminControllers
{
    [Route("api/Admin/Roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        // GET: api/Admin/Roles
        [HttpGet]
        public IEnumerable<string> GetRoles()
        {
            Console.WriteLine("CalledGetRoles() method");
            return new string[] { "value1", "value2" };
        }

        // GET api/Admin/Roles/5
        [HttpGet("{id}")]
        public string GetRole(int id)
        {
            Console.WriteLine("Called GetRole(id) method");
            return "value";
        }

        // POST api/Admin/Roles
        [HttpPost]
        public void AddRole([FromBody] string value)
        {
            Console.WriteLine("Called AddRole(obj) method");
        }

        // PUT api/Admin/Roles/5
        [HttpPut("{id}")]
        public void EditRole(int id, [FromBody] string value)
        {
            Console.WriteLine("Called EditRole(id, obj) method");
        }

        // DELETE api/Admin/Roles/5
        [HttpDelete("{id}")]
        public void DeleteRole(int id)
        {
            Console.WriteLine("Called DeleteRole(id) method");
        }
    }
}
