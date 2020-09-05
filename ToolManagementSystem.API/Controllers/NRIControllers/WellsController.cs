using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToolManagementSystem.API.Controllers.NRIControllers
{
    [Route("api/NRI/Wells")]
    [ApiController]
    public class WellsController : ControllerBase
    { 
        // GET: api/NRI/Wells
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Console.WriteLine("Called Wells Get method");
            return new string[] { "value1", "value2" };
        }

        // GET api/NRI/Wells/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            Console.WriteLine("Called Wells Get(id) method");
            return "value";
        }

        // POST api/NRI/Wells
        [HttpPost]
        public void Post([FromBody] string value)
        {
            Console.WriteLine("Called Wells Post(obj) method");
        }

        // PUT api/NRI/Wells/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            Console.WriteLine("Called Wells Put(id, obj) method");
        }

        // DELETE api/NRI/Wells/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Console.WriteLine("Called Delete(id) method");
        }

    }
}
