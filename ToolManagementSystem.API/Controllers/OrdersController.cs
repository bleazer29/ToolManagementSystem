using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToolManagementSystem.API.Controllers
{
    [Route("api/Orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // GET: api/Orders
        [HttpGet]
        public IEnumerable<string> GetOrders()
        {
            Console.WriteLine("Called GetOrders() method");
            return new string[] { "value1", "value2" };
        }

        // GET api/Orders/5
        [HttpGet("{id}")]
        public string GetOrder(int id)
        {
            Console.WriteLine("Called GetOrder(id) method");
            return "value";
        }

        // POST api/Orders
        [HttpPost]
        public void AddOrder([FromBody] string value)
        {
            Console.WriteLine("Called Orders Post(obj) method");
        }

        // PUT api/Orders/5
        [HttpPut("{id}")]
        public void EditOrder(int id, [FromBody] string value)
        {
            Console.WriteLine("Called EditOrder(id, obj) method");
        }

        // POST api/Orders
        [Route("api/Orders/{id}/Tools")]
        [HttpPut]
        public void EditOrderTools(int id, [FromBody] string value)
        {
            Console.WriteLine("Called EditOrderTools(id, obj) method");
        }

        // DELETE api/Orders/5
        [HttpDelete("{id}")]
        public void DeleteOrder(int id)
        {
            Console.WriteLine("Called DeleteOrder(id) method");
        }
    }
}
