using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToolManagementSystem.API.Controllers.NRIControllers
{
    [Route("api/NRI/Statuses")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        // GET: api/NRI/Statuses
        [HttpGet]
        public IEnumerable<string> GetStatuses()
        {
            Console.WriteLine("Called GetStatuses() method");
            return new string[] { "value1", "value2" };
        }

        // GET api/NRI/Statuses/5
        [HttpGet("{id}")]
        public string GetStatus(int id)
        {
            Console.WriteLine("Called GetStatus(id) method");
            return "value";
        }

        // POST api/NRI/Statuses
        [HttpPost]
        public void AddStatus([FromBody] string value)
        {
            Console.WriteLine("Called AddStatus(obj) method");
        }

        // PUT api/NRI/Statuses/5
        [HttpPut("{id}")]
        public void EditStatus(int id, [FromBody] string value)
        {
            Console.WriteLine("Called EditStatus(id, obj) method");
        }

        // DELETE api/NRI/Statuses/5
        [HttpDelete("{id}")]
        public void DeleteStatus(int id)
        {
            Console.WriteLine("Called DeleteStatus(id) method");
        }
    }
}
