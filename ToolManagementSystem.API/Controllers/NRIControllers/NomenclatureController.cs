using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolManagementSystem.Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToolManagementSystem.API.Controllers.NRIControllers
{
    [Route("api/NRI/Nomenclature")]
    [ApiController]
    public class NomenclatureController : ControllerBase
    {
        private readonly TMSdbContext db;

        public NomenclatureController(TMSdbContext context)
        {
            db = context;
        }

        // GET: api/NRI/Nomenclature
        [HttpGet]
        public async Task<IActionResult> GetNomenclature(string name, string vendorCode)
        {
            List<Nomenclature> nomenclature = await db.Nomenclature
                .Include(x => x.NomenclatureSpecificationUnit)
                        .ThenInclude(x => x.Specification)
                       .Include(x => x.NomenclatureSpecificationUnit)
                        .ThenInclude(x => x.Unit)
                .ToListAsync();
            if (string.IsNullOrEmpty(name) == false)
            {
                nomenclature = nomenclature.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
            }
            if (string.IsNullOrEmpty(vendorCode) == false)
            {
                nomenclature = nomenclature.Where(x => x.VendorCode.ToLower().Contains(vendorCode.ToLower())).ToList();
            }
            return Ok(nomenclature);
        }

        // GET api/NRI/Nomenclature/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNomenclature(int id)
        {
            try
            {
                Nomenclature nomenclature = await db.Nomenclature
                       .Include(x => x.NomenclatureSpecificationUnit)
                               .ThenInclude(x => x.Specification)
                       .Include(x => x.NomenclatureSpecificationUnit)
                               .ThenInclude(x => x.Unit)
                       .SingleAsync(x => x.NomenclatureId == id);
                return Ok(nomenclature);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // POST api/NRI/Nomenclature
        [HttpPost]
        public async Task<IActionResult> AddNomenclature([FromBody] Nomenclature value)
        {
            try
            {
                List<Unit> units = await db.Unit.ToListAsync();
                foreach(NomenclatureSpecificationUnit item in value.NomenclatureSpecificationUnit)
                {
                    Unit unit = units.Where(x => x.Name == item.Unit.Name).FirstOrDefault();
                    await AddUnitIfNotExist(unit);
                }
                await db.Nomenclature.AddAsync(value);
                Nomenclature nomenclature = await db.Nomenclature.SingleAsync(x => x.Name == value.Name);
                await AddNomenclatureAttributes(value.NomenclatureSpecificationUnit, nomenclature.NomenclatureId);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        public async Task AddUnitIfNotExist(Unit unit)
        {
            if (unit == null)
            {
                await db.Unit.AddAsync(unit);
                await db.SaveChangesAsync();
            }
        }

        public async Task AddNomenclatureAttributes(ICollection<NomenclatureSpecificationUnit> specificationUnits, int nomenclatureId)
        {
            foreach (var item in specificationUnits)
            {
                item.NomenclatureId = nomenclatureId;
                item.UnitId = db.Unit.Single(x => x.Name == item.Unit.Name).UnitId;
                await db.NomenclatureSpecificationUnit.AddAsync(item);
                await db.SaveChangesAsync();
            }
        }

        // PUT api/NRI/Nomenclature/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditNomenclature(int id, [FromBody] Nomenclature value)
        {
            try
            {
                Nomenclature nomenclature = await db.Nomenclature.SingleAsync(x => x.NomenclatureId == id);
                if(nomenclature != null)
                {
                    nomenclature.Name = value.Name;
                    nomenclature.VendorCode = value.VendorCode;
                    if (value.NomenclatureSpecificationUnit.Count > 0)
                    {
                        foreach(var specUnit in value.NomenclatureSpecificationUnit)
                        {
                            specUnit.NomenclatureId = id;
                        }
                    }
                }
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }

        // DELETE api/NRI/Nomenclature/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNomenclature(int id)
        {
            try
            {
                Nomenclature nomenclature = await db.Nomenclature.SingleAsync(x => x.NomenclatureId == id);
                db.Nomenclature.Remove(nomenclature);
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
