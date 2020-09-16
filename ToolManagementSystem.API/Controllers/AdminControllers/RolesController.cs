using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolManagementSystem.Shared.Models;

namespace ToolManagementSystem.API.Controllers.AdminControllers
{
    [Route("api/Admin/Roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly TMSdbContext db;

        public RolesController(TMSdbContext context)
        {
            db = context;
        }

        // GET: api/Admin/Roles
        [HttpGet]
        public async Task<IActionResult> GetRoles(string name)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // GET api/Admin/Roles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRole(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // POST api/Admin/Roles
        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] string value)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // PUT api/Admin/Roles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditRole(int id, [FromBody] string value)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // DELETE api/Admin/Roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
    }
}
