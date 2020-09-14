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
        private List<ToolClassification> ClassificationListForClient = new List<ToolClassification>();

        public ClassificationController(TMSdbContext context)
        {
            db = context;
        }

        // GET: api/NRI/Classification
        [HttpGet]
        public async Task<IActionResult> GetClassifications(string name)
        {
            try
            {
                ClassificationListForClient = await db.ToolClassification.ToListAsync();
                if (string.IsNullOrEmpty(name) == false)
                {
                    ClassificationListForClient = FilterClassifications(ClassificationListForClient, name);
                }
                ClearNodeReferencesInClientList();
                return Ok(ClassificationListForClient);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // Clearing all parent and children obj references for optimizing response size
        public void ClearNodeReferencesInClientList()
        {
            foreach (ToolClassification item in ClassificationListForClient)
            {
                item.ParentToolClassification = null;
                item.InverseParentToolClassification = null;
            }
        }

        public List<ToolClassification> FilterClassifications(List<ToolClassification> classifications, string nameFilter)
        {
            classifications = classifications.Where(x => x.Name.ToLower().Contains(nameFilter.ToLower())).ToList();
            BuildClassificationListForClient(classifications);
            return classifications;
        }

        // Build list for client jstree plugin
        public void BuildClassificationListForClient(List<ToolClassification> classifications)
        {
            foreach (ToolClassification classification in classifications)
            {
                ClassificationListForClient.Add(classification);
                GetClassificationParent(classification);
            }
        }

        public void GetClassificationParent(ToolClassification node)
        {
            if(node.ParentToolClassification != null)
            {
                ClassificationListForClient.Add(node.ParentToolClassification);
                GetClassificationParent(node.ParentToolClassification);
            }
        }

        // GET api/NRI/Classification/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassification(int id)
        {
            try
            {
                ToolClassification classification = await db.ToolClassification.SingleAsync(x => x.ToolClassificationId == id);
                return Ok(classification);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // POST api/NRI/Classification
        [HttpPost]
        public async Task<IActionResult> AddClassification([FromBody] ToolClassification value)
        {
            try
            {
                await db.ToolClassification.AddAsync(value);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // PUT api/NRI/Classification/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditClassification(int id, [FromBody] ToolClassification value)
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
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // DELETE api/NRI/Classification/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassification(int id)
        {
            try
            {
                ToolClassification classification = await db.ToolClassification
                    .Include(x => x.InverseParentToolClassification)
                    .SingleAsync(x => x.ToolClassificationId == id);
                if(classification.ParentToolClassificationId != null &&
                    classification.InverseParentToolClassification.Any() == false)
                {
                    db.ToolClassification.Remove(classification);
                    await db.SaveChangesAsync();
                    return Ok();
                }
                return Problem(statusCode: 412, detail: "Нельзя удалить узел классификации, который имеет родительский или дочерние узлы");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
    }
}
