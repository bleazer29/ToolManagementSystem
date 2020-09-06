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
        public IEnumerable<string> GetAttributes()
        {
            Console.WriteLine("Called GetAttributes() method");
            return new string[] { "value1", "value2" };
        }

        // GET api/NRI/Attributes/5
        [HttpGet("{id}")]
        public string GetAttribute(int id)
        {
            Console.WriteLine("Called GetAttribute(id) method");
            return "value";
        }

        // POST api/NRI/Attributes
        [HttpPost]
        public void AddAttribute([FromBody] string value)
        {
            Console.WriteLine("Called AddAttribute(obj) method");
        }

        // PUT api/NRI/Attributes/5
        [HttpPut("{id}")]
        public void EditAttribute(int id, [FromBody] string value)
        {
            Console.WriteLine("Called EditAttribute(id, obj) method");
        }

        // DELETE api/NRI/Attributes/5
        [HttpDelete("{id}")]
        public void DeleteAttribute(int id)
        {
            Console.WriteLine("Called DeleteAttribute(id) method");
        }

    }
}
