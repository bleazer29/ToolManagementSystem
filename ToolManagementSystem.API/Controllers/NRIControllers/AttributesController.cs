using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToolManagementSystem.API.Controllers.NRIControllers
{
    [Route("api/NRI/Attributes")]
    [ApiController]
    public class AttributesController : ControllerBase
    {
        // GET: api/NRI/Attributes
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Console.WriteLine("Called Attributes Get method");
            return new string[] { "value1", "value2" };
        }

        // GET api/NRI/Attributes/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            Console.WriteLine("Called Attributes Get(id) method");
            return "value";
        }

        // POST api/NRI/Attributes
        [HttpPost]
        public void Post([FromBody] string value)
        {
            Console.WriteLine("Called Attributes Post(obj) method");
        }

        // PUT api/NRI/Attributes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            Console.WriteLine("Called Attributes Put(id, obj) method");
        }

        // DELETE api/NRI/Attributes/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Console.WriteLine("Called Delete(id) method");
        }

    }
}
