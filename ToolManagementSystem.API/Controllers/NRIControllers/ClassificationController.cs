﻿using System;
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
        public async Task<IActionResult> GetClassifications(string name)
        {
            try
            {
                List<ToolClassification> classifications = await db.ToolClassification.ToListAsync();
                if (string.IsNullOrEmpty(name) == false)
                {
                    classifications = classifications.Where(x => x.Name.Contains(name)).ToList();
                }
                return Ok(classifications);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
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
                ToolClassification classification = await db.ToolClassification.SingleAsync(x => x.ToolClassificationId == id);
                db.ToolClassification.Remove(classification);
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
