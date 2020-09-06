using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToolManagementSystem.API.Controllers.NRIControllers
{
    [Route("api/NRI/Counterparties")]
    [ApiController]
    public class CounterpartiesController : ControllerBase
    { 
        // GET: api/NRI/Counterparties
        [HttpGet]
        public IEnumerable<string> GetCounterparties()
        {
            Console.WriteLine("Called GetCounterparties() method");
            return new string[] { "value1", "value2" };
        }

        // GET api/NRI/Counterparties/5
        [HttpGet("{id}")]
        public string GetCounterparty(int id)
        {
            Console.WriteLine("Called GetCounterparty(id) method");
            return "value";
        }

        // POST api/NRI/Counterparties
        [HttpPost]
        public void AddCounterparty([FromBody] string value)
        {
            Console.WriteLine("Called AddCounterparty(obj) method");
        }

        // PUT api/NRI/Counterparties/5
        [HttpPut("{id}")]
        public void EditCounterparty(int id, [FromBody] string value)
        {
            Console.WriteLine("Called EditCounterparty(id, obj) method");
        }

        // DELETE api/NRI/Counterparties/5
        [HttpDelete("{id}")]
        public void DeleteCounterparty(int id)
        {
            Console.WriteLine("Called DeleteCounterparty(id) method");
        }
    }
}
