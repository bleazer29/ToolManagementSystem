using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToolManagementSystem.API.Controllers
{
    [Route("api/Maintenances")]
    [ApiController]
    public class MaintenancesController : ControllerBase
    {
        // GET: api/Maintenances
        [HttpGet]
        public IEnumerable<string> GetMaintenances()
        {
            Console.WriteLine("Called GetMaintenances method");
            return new string[] { "value1", "value2" };
        }

        // GET api/Maintenances/5
        [HttpGet("{id}")]
        public string GetMaintenance(int id)
        {
            Console.WriteLine("Called GetMaintenance(id) method");
            return "value";
        }

        // POST api/Maintenances
        [HttpPost]
        public void AddMaintenance([FromBody] string value)
        {
            Console.WriteLine("Called AddMaintenance(obj) method");
        }

        // POST api/Maintenances
        [Route("api/Maintenances/{id}/Tools")]
        [HttpPost]
        public void EditMaintenanceTools(int id, [FromBody] string value)
        {
            Console.WriteLine("Called EditMaintenanceTools(obj) method");
        }

        // PUT api/Maintenances/5
        [HttpPut("{id}")]
        public void EditMaintenance(int id, [FromBody] string value)
        {
            Console.WriteLine("Called EditMaintenance(id, obj) method");
        }

        // DELETE api/Maintenances/5
        [HttpDelete("{id}")]
        public void DeleteMaintenance(int id)
        {
            Console.WriteLine("Called DeleteMaintenance(id) method");
        }
    }
}
