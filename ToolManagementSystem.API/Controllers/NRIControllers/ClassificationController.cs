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
    [Route("api/NRI/Classification")]
    [ApiController]
    public class ClassificationController : ControllerBase
    {
        private readonly TMSdbContext db;

        public ClassificationController(TMSdbContext context)
        {
            db = context;
        }

        // GET: api/NRI/Classification
        [HttpGet]
        public async Task<List<ToolClassification>> GetClassifications(string name)
        {
            List<ToolClassification> classifications = await db.ToolClassification.ToListAsync();
            if (string.IsNullOrEmpty(name))
            {
                classifications = classifications.Where(x => x.Name == name).ToList();
            }
            return classifications;
        }

        // GET api/NRI/Classification/5
        [HttpGet("{id}")]
        public async Task<ToolClassification> GetClassification(int id)
        {
            ToolClassification classification = await db.ToolClassification.SingleAsync(x => x.ToolClassificationId == id);
            return classification;
        }

        // POST api/NRI/Classification
        [HttpPost]
        public async Task AddClassification([FromBody] ToolClassification value)
        {
            try
            {
                ToolClassification classification = new ToolClassification();
                classification = value;
                await db.ToolClassification.AddAsync(classification);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // PUT api/NRI/Classification/5
        [HttpPut("{id}")]
        public async Task EditClassification(int id, [FromBody] ToolClassification value)
        {
            try
            {
                ToolClassification classification = await db.ToolClassification.SingleAsync(x => x.ToolClassificationId == id);
                if(classification != null)
                {
                    classification.Name = value.Name;
                    classification.ToolClassificationId = value.ToolClassificationId;
                    classification.ParentToolClassificationId = value.ParentToolClassificationId;
                }
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // DELETE api/NRI/Classification/5
        [HttpDelete("{id}")]
        public async Task DeleteClassification(int id)
        {
            try
            {
                ToolClassification classification = await db.ToolClassification.SingleAsync(x => x.ToolClassificationId == id);
                db.ToolClassification.Remove(classification);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
