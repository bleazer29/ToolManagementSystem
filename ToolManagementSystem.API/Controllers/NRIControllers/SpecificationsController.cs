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

        //SpecificationUnit - specifications with measurement units
        // GET: api/NRI/Specifications/SpecificationUnits
        [HttpGet("SpecificationUnits")]
        public async Task<IActionResult> GetSpecificationUnits(string name, string unit)
        {
            try
            {
                List<SpecificationUnit> specifications = await db.SpecificationUnit
                    .Include(x => x.Specification)
                    .Include(x => x.Unit)
                    .ToListAsync();
                if (string.IsNullOrEmpty(name))
                {
                    specifications = specifications.Where(x => x.Specification.Name == name).ToList();
                }
                if (string.IsNullOrEmpty(unit))
                {
                    specifications = specifications.Where(x => x.Unit.Name == unit).ToList();
                }
                return Ok(specifications);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
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
                    specifications = specifications.Where(x => x.Name == name).ToList();
                }
                return Ok(specifications);
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
                return Ok(await db.Specification.SingleAsync(x => x.Name == value.Name));
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
                    if(value.SpecificationUnit.Count > 0)
                    {
                        specification.SpecificationUnit = value.SpecificationUnit;
                    }
                }
                await db.SaveChangesAsync();
                return Ok(specification);
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
