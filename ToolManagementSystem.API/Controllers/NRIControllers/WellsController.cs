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
        public IEnumerable<string> GetWells()
        {
            Console.WriteLine("Called GetWells() method");
            return new string[] { "value1", "value2" };
        }

        // GET api/NRI/Wells/5
        [HttpGet("{id}")]
        public string GetWell(int id)
        {
            Console.WriteLine("Called GetWell(id) method");
            return "value";
        }

        // POST api/NRI/Wells
        [HttpPost]
        public void AddWell([FromBody] string value)
        {
            Console.WriteLine("Called AddWell(obj) method");
        }

        // PUT api/NRI/Wells/5
        [HttpPut("{id}")]
        public void EditWell(int id, [FromBody] string value)
        {
            Console.WriteLine("Called EditWell(id, obj) method");
        }

        // DELETE api/NRI/Wells/5
        [HttpDelete("{id}")]
        public void DeleteWell(int id)
        {
            Console.WriteLine("Called DeleteWell(id) method");
        }

    }
}
