using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToolManagementSystem.API.Controllers.AdminControllers
{
    [Route("api/Admin/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/Admin/Users
        [HttpGet]
        public IEnumerable<string> GetUsers()
        {
            Console.WriteLine("Called GetUsers() method");
            return new string[] { "value1", "value2" };
        }

        // GET api/Admin/Users/5
        [HttpGet("{id}")]
        public string GetUser(int id)
        {
            Console.WriteLine("Called GetUser(id) method");
            return "value";
        }

        // POST api/Admin/Users
        [HttpPost]
        public void AddUser([FromBody] string value)
        {
            Console.WriteLine("Called AddUser(obj) method");
        }

        // PUT api/Admin/Users/5
        [HttpPut("{id}")]
        public void EditUser(int id, [FromBody] string value)
        {
            Console.WriteLine("Called EditUser(id, obj) method");
        }

        // DELETE api/Admin/Users/5
        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
            Console.WriteLine("Called DeleteUser(id) method");
        }
    }
}
