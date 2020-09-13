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
    [Route("api/NRI/Specifications")]
    [ApiController]
    public class SpecificationsController : ControllerBase
    {
        private readonly TMSdbContext db;

        public SpecificationsController(TMSdbContext context)
        {
            db = context;
        }

        // GET api/NRI/Specifications/
        [HttpGet]
        public async Task<IActionResult> GetSpecifications(string name)
        {
            try
            {
                List<Specification> specifications = await db.Specification.ToListAsync();
                if (string.IsNullOrEmpty(name))
                {
                    specifications = specifications.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
                }
                return Ok(specifications);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }


        // GET api/NRI/Specifications/Units
        [HttpGet("/Units")]
        public async Task<IActionResult> GetUnits()
        {
            try
            {
                List<Unit> units = await db.Unit.ToListAsync();
                return Ok(units);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // POST api/NRI/Specifications
        [HttpPost]
        public async Task<IActionResult> AddSpecification([FromBody] Specification value)
        {
            try
            {
                await db.Specification.AddAsync(value);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // PUT api/NRI/Specifications/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditSpecifications(int id, [FromBody] Specification value)
        {
            try
            {
                Specification specification = await db.Specification.SingleAsync(x => x.SpecificationId == id);
                if(specification != null)
                {
                    specification.Name = value.Name;
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

        // DELETE api/NRI/Specifications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecifications(int id)
        {
            try
            {
                Specification specification = db.Specification.Single(x => x.SpecificationId == id);
                db.Specification.Remove(specification);
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
