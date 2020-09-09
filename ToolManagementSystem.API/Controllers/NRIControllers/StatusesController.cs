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
        public async Task<List<ToolStatus>> GetStatuses(string name)
        {
            List<ToolStatus> statuses = new List<ToolStatus>();
            statuses = await db.ToolStatus.ToListAsync();
            if (string.IsNullOrEmpty(name) == false)
            {
                statuses = statuses.Where(x => x.Name == name).ToList();
            }
            return statuses;
        }

        // GET api/NRI/Statuses/5
        [HttpGet("{id}")]
        public async Task<ToolStatus> GetStatus(int id)
        {
            ToolStatus status = await db.ToolStatus.SingleAsync(x => x.ToolStatusId == id);
            return status;
        }

        // POST api/NRI/Statuses
        [HttpPost]
        public async Task AddStatus([FromBody] ToolStatus value)
        {
            try
            {
                ToolStatus status = new ToolStatus();
                status = value;
                await db.ToolStatus.AddAsync(status);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // PUT api/NRI/Statuses/5
        [HttpPut("{id}")]
        public async Task EditStatus(int id, [FromBody] ToolStatus value)
        {
            try
            {
                ToolStatus status = await db.ToolStatus.SingleAsync(x => x.ToolStatusId == id);
                if (status != null)
                {
                    status.Name = value.Name;
                }
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // DELETE api/NRI/Statuses/5
        [HttpDelete("{id}")]
        public async Task DeleteStatus(int id)
        {
            try
            {
                ToolStatus status = await db.ToolStatus.SingleAsync(x => x.ToolStatusId == id);
                db.ToolStatus.Remove(status);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
