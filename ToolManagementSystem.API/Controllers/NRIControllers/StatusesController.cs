using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolManagementSystem.Shared.Models;

namespace ToolManagementSystem.API.Controllers.NRIControllers
{

    [Route("api/NRI/Statuses")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        private readonly TMSdbContext db;

        public StatusesController(TMSdbContext context)
        {
            db = context;
        }

        // GET: api/NRI/Statuses
        [HttpGet]
        public async Task<IActionResult> GetStatuses(string name)
        {
            try
            {
                List<ToolStatus> statuses = new List<ToolStatus>();
                statuses = await db.ToolStatus.ToListAsync();
                if (string.IsNullOrEmpty(name) == false)
                {
                    statuses = statuses.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
                }
                return Ok(statuses);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // GET api/NRI/Statuses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStatus(int id)
        {
            try
            {
                ToolStatus status = await db.ToolStatus.SingleAsync(x => x.ToolStatusId == id);
                return Ok(status);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // POST api/NRI/Statuses
        [HttpPost]
        public async Task<IActionResult> AddStatus([FromBody] ToolStatus value)
        {
            try
            {
                await db.ToolStatus.AddAsync(value);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // PUT api/NRI/Statuses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditStatus(int id, [FromBody] ToolStatus value)
        {
            try
            {
                ToolStatus status = await db.ToolStatus.SingleAsync(x => x.ToolStatusId == id);
                if (status != null)
                {
                    status.Name = value.Name;
                }
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // DELETE api/NRI/Statuses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            try
            {
                ToolStatus status = await db.ToolStatus.SingleAsync(x => x.ToolStatusId == id);
                db.ToolStatus.Remove(status);
                await db.SaveChangesAsync();
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
