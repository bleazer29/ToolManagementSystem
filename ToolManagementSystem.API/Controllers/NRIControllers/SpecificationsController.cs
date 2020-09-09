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
        public async Task<List<SpecificationUnit>> GetSpecificationUnits(string name, string unit)
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
            return specifications;
        }

        // GET api/NRI/Specifications/
        [HttpGet]
        public async Task<List<Specification>> GetSpecifications(string name)
        {
            List<Specification> specifications = await db.Specification.ToListAsync();
            if (string.IsNullOrEmpty(name))
            {
                specifications = specifications.Where(x => x.Name == name).ToList();
            }
            return specifications;
        }

        // POST api/NRI/Specifications
        [HttpPost]
        public async Task AddSpecification([FromBody] Specification value)
        {
            try
            {
                await db.Specification.AddAsync(value);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // PUT api/NRI/Specifications/5
        [HttpPut("{id}")]
        public async Task EditSpecifications(int id, [FromBody] Specification value)
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
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // DELETE api/NRI/Specifications/5
        [HttpDelete("{id}")]
        public async Task DeleteSpecifications(int id)
        {
            try
            {
                Specification specification = db.Specification.Single(x => x.SpecificationId == id);
                db.Specification.Remove(specification);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
