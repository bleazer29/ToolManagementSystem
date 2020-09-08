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
        // GET: api/NRI/SpecificationUnits
        [Route("api/NRI/SpecificationUnits")]
        [HttpGet]
        public List<SpecificationUnit> GetSpecificationUnits(string name, string unit)
        {
            List<SpecificationUnit> specifications = db.SpecificationUnit
                .Include(x => x.Specification)
                .Include(x => x.Unit)
                .ToList();
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

        // GET api/NRI/Specifications/5
        [HttpGet]
        public List<Specification> GetSpecifications(string name)
        {
            List<Specification> specifications = db.Specification.ToList();
            if (string.IsNullOrEmpty(name))
            {
                specifications = specifications.Where(x => x.Name == name).ToList();
            }
            return specifications;
        }

        // POST api/NRI/Specifications
        [HttpPost]
        public void AddSpecification([FromBody] Specification value)
        {
            try
            {
                Specification specification = new Specification();
                specification = value;
                db.Specification.Add(specification);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // PUT api/NRI/Specifications/5
        [HttpPut("{id}")]
        public void EditSpecifications(int id, [FromBody] Specification value)
        {
            try
            {
                Specification specification = db.Specification.Single(x => x.SpecificationId == id);
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
        public void DeleteSpecifications(int id)
        {
            try
            {
                Specification specification = db.Specification.Single(x => x.SpecificationId == id);
                db.Specification.Remove(specification);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
