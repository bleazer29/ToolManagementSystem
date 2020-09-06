using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToolManagementSystem.API.Controllers
{
    [Route("api/Contracts")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        // GET: api/Contracts
        [HttpGet]
        public IEnumerable<string> GetContracts()
        {
            Console.WriteLine("Called GetContracts() method");
            return new string[] { "value1", "value2" };
        }

        // GET api/Contracts/5
        [HttpGet("{id}")]
        public string GetContract(int id)
        {
            Console.WriteLine("Called GetContract(id) method");
            return "value";
        }

        // POST api/Contracts
        [HttpPost]
        public void AddContract([FromBody] string value)
        {
            Console.WriteLine("Called Contracts Post(obj) method");
        }

        // PUT api/Contracts/5
        [HttpPut("{id}")]
        public void EditContract(int id, [FromBody] string value)
        {
            Console.WriteLine("Called EditContract(id, obj) method");
        }

        // DELETE api/Contracts/5
        [HttpDelete("{id}")]
        public void DeleteContract(int id)
        {
            Console.WriteLine("Called DeleteContract(id) method");
        }
    }
}
