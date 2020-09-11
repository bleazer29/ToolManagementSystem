using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolManagementSystem.API.Helpers;
using ToolManagementSystem.Shared.Models;

namespace ToolManagementSystem.API.Controllers
{
    [Route("api/Tools")]
    [ApiController]
    public class ToolController : ControllerBase
    {
        private readonly TMSdbContext db;
        private HistoryWriter HistoryWriter;

        public ToolController(TMSdbContext context)
        {
            db = context;
            HistoryWriter = new HistoryWriter();
        }


        // GET: api/Tools
        [HttpGet]
        public async Task<IActionResult> GetTools(string name)
        {
            try
            {
                List<Tool> tools = await db.Tool
                    .Include(x => x.Department)
                    .Include(x => x.Nomenclature)
                    .Include(x => x.ToolClassification)
                    .Include(x => x.ToolStatus)
                    .ToListAsync();
                if (string.IsNullOrEmpty(name) == false)
                {
                    tools = tools.Where(x => x.Name == name).ToList();
                }
                return Ok(tools);
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
                Tool tool = await db.Tool
                    .Include(x => x.Department)
                    .Include(x => x.Nomenclature)
                    .Include(x => x.ToolClassification)
                    .Include(x => x.ToolStatus)
                    .SingleAsync(x => x.ToolId == id);
                return Ok(tool);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // POST api/Tools
        [HttpPost]
        public async Task<IActionResult> AddTool(int userId, [FromBody] Tool value)
        {
            try
            {
                await db.Tool.AddAsync(value);
                await db.SaveChangesAsync();
                Tool addedTool = await db.Tool.SingleAsync(x => x.Name == value.Name);
                string historyMessage = "Инструмент добавлен в базу";
                await HistoryWriter.WriteToolHistory(addedTool.ToolId, userId, addedTool.ToolStatusId, historyMessage, comment: null);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // POST api/Tools/5
        [HttpPost("{id}")]
        public async Task<IActionResult> AddToolCommentary(int id, int userId, [FromBody] string comment)
        {
            try
            {
                Tool tool = await db.Tool.SingleAsync(x => x.ToolId == id);
                string historyMessage = "К инструменту написан комментарий";
                await HistoryWriter.WriteToolHistory(id, userId, tool.ToolStatusId, historyMessage, comment);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // PUT api/Tools/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditTool(int id, int userId, [FromBody] Tool value)
        {
            try
            {
                Tool tool = await db.Tool.SingleAsync(x => x.ToolId == id);
                if (tool != null)
                {
                    tool.Name = value.Name;
                }
                await db.SaveChangesAsync();
                string historyMessage = "Данные об инструменте отредактированы";
                await HistoryWriter.WriteToolHistory(tool.ToolId, userId, tool.ToolStatusId, historyMessage, comment: null);
                return Ok();
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
                Tool tool = await db.Tool
                    .Include(x => x.ToolStatus)
                    .SingleAsync(x => x.ToolId == id);
                if(tool.ToolStatus.Name == "RFU" || tool.ToolStatus.Name == "Scrap")
                {
                    db.Tool.Remove(tool);
                    await db.SaveChangesAsync();
                    return Ok();
                }
                return Conflict();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
    }
}
