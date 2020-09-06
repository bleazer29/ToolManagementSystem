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
        public IEnumerable<string> GetNomenclature()
        {
            Console.WriteLine("Called GetNomenclature() method");
            return new string[] { "value1", "value2" };
        }

        // GET api/NRI/Nomenclature/5
        [HttpGet("{id}")]
        public string GetNomenclature(int id)
        {
            Console.WriteLine("Called GetNomenclature(id) method");
            return "value";
        }

        // POST api/NRI/Nomenclature
        [HttpPost]
        public void AddNomenclature([FromBody] string value)
        {
            Console.WriteLine("Called AddNomenclature(obj) method");
        }

        // PUT api/NRI/Nomenclature/5
        [HttpPut("{id}")]
        public void EditNomenclature(int id, [FromBody] string value)
        {
            Console.WriteLine("Called EditNomenclature(id, obj) method");
        }

        // DELETE api/NRI/Nomenclature/5
        [HttpDelete("{id}")]
        public void DeleteNomenclature(int id)
        {
            Console.WriteLine("Called DeleteNomenclature(id) method");
        }
    }
}
