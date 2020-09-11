using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolManagementSystem.Shared.Models;

namespace ToolManagementSystem.API.Controllers
{
    [Route("api/Tools")]
    [ApiController]
    public class ToolController : ControllerBase
    {
        private readonly TMSdbContext db;

        public ToolController(TMSdbContext context)
        {
            db = context;
        }


        // GET: api/Tools
        [HttpGet]
        public async Task<IActionResult> GetTools(string name)
        {
            try
            {
                List<Tool> contracts = await db.Tool
                    .Include(x => x.Department)
                    .Include(x => x.Nomenclature)
                    .Include(x => x.ToolClassification)
                    .Include(x => x.ToolStatus)
                    .ToListAsync();
                if (string.IsNullOrEmpty(name) == false)
                {
                    contracts = contracts.Where(x => x.Name == name).ToList();
                }
                return Ok(contracts);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // GET api/Tools/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTool(int id)
        {
            try
            {
                Tool contract = await db.Tool.SingleAsync(x => x.ToolId == id);
                return Ok(contract);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // POST api/Tools
        [HttpPost]
        public async Task<IActionResult> AddTool([FromBody] Tool value)
        {
            try
            {
                await db.Tool.AddAsync(value);
                await db.SaveChangesAsync();
                return Ok(await db.Tool.SingleAsync(x => x.Name == value.Name));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // PUT api/Tools/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditTool(int id, [FromBody] Tool value)
        {
            try
            {
                Tool contract = await db.Tool.SingleAsync(x => x.ToolId == id);
                if (contract != null)
                {
                    contract.Name = value.Name;
                }
                await db.SaveChangesAsync();
                return Ok(contract);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // DELETE api/Tools/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTool(int id)
        {
            try
            {
                Tool contract = await db.Tool.SingleAsync(x => x.ToolId == id);
                db.Tool.Remove(contract);
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
