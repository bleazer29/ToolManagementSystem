using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolManagementSystem.Shared.Models;
using ToolManagementSystem.Shared.RequestModels.NRI;

namespace ToolManagementSystem.API.Controllers.NRIControllers
{
    [Route("api/NRI/Wells")]
    [ApiController]
    public class WellsController : ControllerBase
    {
        private readonly TMSdbContext db;

        public WellsController(TMSdbContext context)
        {
            db = context;
        }

        // GET: api/NRI/Wells
        [HttpGet]
        public async Task<List<Well>> GetWells([FromBody] WellFilterRequest request)
        {
            List<Well> wells = new List<Well>();
            wells = await db.Well
                .Include(x => x.CounterpartyId)
                .ToListAsync();
            if (string.IsNullOrEmpty(request.Name) == false)
            {
                wells = wells.Where(x => x.Name == request.Name).ToList();
            }
            if (string.IsNullOrEmpty(request.Address) == false)
            {
                wells = wells.Where(x => x.Address == request.Address).ToList();
            }
            return wells;
        }

        // GET api/NRI/Wells/5
        [HttpGet("{id}")]
        public async Task<Well> GetWell(int id)
        {
            try { 
            Well well = await db.Well.SingleAsync(x => x.WellId == id);
            return well;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Well() { WellId = -1 };
            }
        }

        // POST api/NRI/Wells
        [HttpPost]
        public async Task AddWell([FromBody] Well value)
        {
            try
            {
                await db.Well.AddAsync(value);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // PUT api/NRI/Wells/5
        [HttpPut("{id}")]
        public async Task EditWell(int id, [FromBody] Well value)
        {
            try
            {
                Well well = await db.Well.SingleAsync(x => x.WellId == id);
                if(well != null)
                {
                    well.Name = value.Name;
                    well.Address = value.Address;
                    well.CounterpartyId = value.CounterpartyId;
                }
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // DELETE api/NRI/Wells/5
        [HttpDelete("{id}")]
        public async Task DeleteWell(int id)
        {
            try
            {
                Well well = await db.Well.SingleAsync(x => x.WellId == id);
                db.Well.Remove(well);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
