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
        public async Task<IActionResult> GetWells(string name, string address, string wellNumber)
        {
            try
            {
                List<Well> wells = new List<Well>();
                wells = await db.Well
                    .Include(x => x.CounterpartyId)
                    .ToListAsync();
                if (string.IsNullOrEmpty(name) == false)
                {
                    wells = wells.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
                }
                if (string.IsNullOrEmpty(address) == false)
                {
                    wells = wells.Where(x => x.Address.ToLower().Contains(address.ToLower())).ToList();
                }
                if (string.IsNullOrEmpty(wellNumber) == false)
                {
                    wells = wells.Where(x => x.WellNumber.ToLower().Contains(wellNumber.ToLower())).ToList();
                }
                return Ok(wells);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // GET api/NRI/Wells/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWell(int id)
        {
            try 
            { 
            Well well = await db.Well.SingleAsync(x => x.WellId == id);
            return Ok(well);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // POST api/NRI/Wells
        [HttpPost]
        public async Task<IActionResult> AddWell([FromBody] Well value)
        {
            try
            {
                await db.Well.AddAsync(value);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // PUT api/NRI/Wells/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditWell(int id, [FromBody] Well value)
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
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // DELETE api/NRI/Wells/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWell(int id)
        {
            try
            {
                Well well = await db.Well.SingleAsync(x => x.WellId == id);
                db.Well.Remove(well);
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
