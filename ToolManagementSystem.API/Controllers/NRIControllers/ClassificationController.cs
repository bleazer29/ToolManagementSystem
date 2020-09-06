using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToolManagementSystem.API.Controllers.NRIControllers
{
    [Route("api/NRI/Classification")]
    [ApiController]
    public class ClassificationController : ControllerBase
    {
        // GET: api/NRI/Classification
        [HttpGet]
        public IEnumerable<string> GetClassifications()
        {
            Console.WriteLine("Called GetClassifications() method");
            return new string[] { "value1", "value2" };
        }

        // GET api/NRI/Classification/5
        [HttpGet("{id}")]
        public string GetClassification(int id)
        {
            Console.WriteLine("Called GetClassification(id) method");
            return "value";
        }

        // POST api/NRI/Classification
        [HttpPost]
        public void AddClassification([FromBody] string value)
        {
            Console.WriteLine("Called AddClassification(obj) method");
        }

        // PUT api/NRI/Classification/5
        [HttpPut("{id}")]
        public void EditClassification(int id, [FromBody] string value)
        {
            Console.WriteLine("Called EditClassification(id, obj) method");
        }

        // DELETE api/NRI/Classification/5
        [HttpDelete("{id}")]
        public void DeleteClassification(int id)
        {
            Console.WriteLine("Called Delete(id) method");
        }
    }
}
