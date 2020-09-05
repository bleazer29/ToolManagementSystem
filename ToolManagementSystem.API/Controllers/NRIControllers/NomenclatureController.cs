using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToolManagementSystem.API.Controllers.NRIControllers
{
    [Route("api/NRI/Nomenclature")]
    [ApiController]
    public class NomenclatureController : ControllerBase
    {
        // GET: api/NRI/Nomenclature
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Console.WriteLine("Called Nomenclature Get method");
            return new string[] { "value1", "value2" };
        }

        // GET api/NRI/Nomenclature/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            Console.WriteLine("Called Nomenclature Get(id) method");
            return "value";
        }

        // POST api/NRI/Nomenclature
        [HttpPost]
        public void Post([FromBody] string value)
        {
            Console.WriteLine("Called Nomenclature Post(obj) method");
        }

        // PUT api/NRI/Nomenclature/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            Console.WriteLine("Called Nomenclature Put(id, obj) method");
        }

        // DELETE api/NRI/Nomenclature/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Console.WriteLine("Called Delete(id) method");
        }
    }
}
