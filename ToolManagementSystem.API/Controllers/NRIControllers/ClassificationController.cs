using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public List<ToolClassification> GetClassifications(string name)
        {
            List<ToolClassification> classifications = db.ToolClassification.ToList();
            if (string.IsNullOrEmpty(name))
            {
                classifications = classifications.Where(x => x.Name == name).ToList();
            }
            return classifications;
        }

        // GET api/NRI/Classification/5
        [HttpGet("{id}")]
        public ToolClassification GetClassification(int id)
        {
            ToolClassification classification = db.ToolClassification.Single(x => x.ToolClassificationId == id);
            return classification;
        }

        // POST api/NRI/Classification
        [HttpPost]
        public void AddClassification([FromBody] ToolClassification value)
        {
            try
            {
                ToolClassification classification = new ToolClassification();
                classification = value;
                db.ToolClassification.Add(classification);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // PUT api/NRI/Classification/5
        [HttpPut("{id}")]
        public void EditClassification(int id, [FromBody] ToolClassification value)
        {
            try
            {
                ToolClassification classification = db.ToolClassification.Single(x => x.ToolClassificationId == id);
                classification = value;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // DELETE api/NRI/Classification/5
        [HttpDelete("{id}")]
        public void DeleteClassification(int id)
        {
            try
            {
                ToolClassification classification = db.ToolClassification.Single(x => x.ToolClassificationId == id);
                db.ToolClassification.Remove(classification);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
