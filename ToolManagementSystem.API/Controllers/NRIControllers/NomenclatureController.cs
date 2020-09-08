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
        public List<Nomenclature> GetNomenclature(string name, string vendorCode)
        {
            List<Nomenclature> nomenclature = db.Nomenclature
                .Include(x => x.NomenclatureSpecificationUnit)
                    .ThenInclude(x => x.SpecificationUnit)
                        .ThenInclude(x => x.Specification)
                    .ThenInclude(x => x.SpecificationUnit)
                        .ThenInclude(x => x.Unit)
                .ToList();
            if (string.IsNullOrEmpty(name))
            {
                nomenclature = nomenclature.Where(x => x.Name == name).ToList();
            }
            if (string.IsNullOrEmpty(vendorCode))
            {
                nomenclature = nomenclature.Where(x => x.VendorCode == vendorCode).ToList();
            }
            return nomenclature;
        }

        // GET api/NRI/Nomenclature/5
        [HttpGet("{id}")]
        public Nomenclature GetNomenclature(int id)
        {
            Nomenclature nomenclature = db.Nomenclature
                   .Include(x => x.NomenclatureSpecificationUnit)
                       .ThenInclude(x => x.SpecificationUnit)
                           .ThenInclude(x => x.Specification)
                       .ThenInclude(x => x.SpecificationUnit)
                           .ThenInclude(x => x.Unit)
                   .Single(x => x.NomenclatureId == id);
            return nomenclature;
        }

        // POST api/NRI/Nomenclature
        [HttpPost]
        public void AddNomenclature([FromBody] Nomenclature value)
        {
            try
            {
                Nomenclature nomenclature = new Nomenclature();
                nomenclature = value;
                db.Nomenclature.Add(nomenclature);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // PUT api/NRI/Nomenclature/5
        [HttpPut("{id}")]
        public void EditNomenclature(int id, [FromBody] Nomenclature value)
        {
            try
            {
                Nomenclature nomenclature = db.Nomenclature.Single(x => x.NomenclatureId == id);
                if(nomenclature != null)
                {
                    nomenclature.Name = value.Name;
                    nomenclature.VendorCode = value.VendorCode;
                    if (value.NomenclatureSpecificationUnit.Count > 0)
                    {
                        nomenclature.NomenclatureSpecificationUnit = value.NomenclatureSpecificationUnit;
                    }
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // DELETE api/NRI/Nomenclature/5
        [HttpDelete("{id}")]
        public void DeleteNomenclature(int id)
        {
            try
            {
                Nomenclature nomenclature = db.Nomenclature.Single(x => x.NomenclatureId == id);
                db.Nomenclature.Remove(nomenclature);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
