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
    [Route("api/WorkOrders")]
    [ApiController]
    public class WorkOrderController : ControllerBase
    {
        private readonly TMSdbContext db;
        private HistoryWriter HistoryWriter;

        public WorkOrderController(TMSdbContext context)
        {
            db = context;
            HistoryWriter = new HistoryWriter();
        }

        // GET: api/WorkOrders/2020-08-11/2020-12-30
        [HttpGet("{startdate:datetime?}/{enddate:datetime?}")]
        public async Task<IActionResult> GetWorkOrders(DateTime? startdate, DateTime? enddate, string name, string responsible, string status)
        {
            try
            {
                List<WorkOrder> workOrders = await db.WorkOrder
                    .Include(x => x.ResponsibleUser)
                    .Include(x => x.WorkOrderStatus)
                    .ToListAsync();
                if (string.IsNullOrEmpty(name) == false)
                {
                    workOrders = workOrders.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
                }
                if (string.IsNullOrEmpty(responsible) == false)
                {
                    workOrders = workOrders.Where(x => x.ResponsibleUser.Fio.ToLower().Contains(responsible.ToLower())).ToList();
                }
                if (string.IsNullOrEmpty(status) == false)
                {
                    workOrders = workOrders.Where(x => x.WorkOrderStatus.Name.ToLower().Contains(status.ToLower())).ToList();
                }
                if(startdate != null)
                {
                    workOrders = workOrders.Where(x => x.StartDate >= startdate).ToList();
                }
                if(enddate != null)
                {
                    workOrders = workOrders.Where(x => x.EndDate <= enddate).ToList();
                }
                return Ok(workOrders);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // GET: api/WorkOrders/Repairs/2020-08-11/2020-12-30
        [HttpGet("Repairs/{startdate:datetime?}/{enddate:datetime?}/{status?}")]
        public async Task<IActionResult> GetRepairs(DateTime? startdate, DateTime? enddate, string responsible)
        {
            try
            {
                List<RepairTool> repairTools = await db.RepairTool
                    .Include(x => x.User)
                    .Include(x => x.Tool)
                    .ToListAsync();
                if (string.IsNullOrEmpty(responsible) == false)
                {
                    repairTools = repairTools.Where(x => x.User.Fio.ToLower().Contains(responsible.ToLower())).ToList();
                }
                if (startdate != null)
                {
                    repairTools = repairTools.Where(x => x.DateStart >= startdate).ToList();
                }
                if (enddate != null)
                {
                    repairTools = repairTools.Where(x => x.DateEnd <= enddate).ToList();
                }
                return Ok(repairTools);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // GET api/WorkOrders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkOrder(int id)
        {
            try
            {
                WorkOrder workOrder = await db.WorkOrder
                    .Include(x => x.ResponsibleUser)
                    .Include(x => x.WorkOrderStatus)
                    .SingleAsync(x => x.WorkOrderId == id);
                return Ok(workOrder);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // POST api/WorkOrders
        [HttpPost]
        public async Task<IActionResult> AddWorkOrder([FromBody] WorkOrder value)
        {
            try
            {
                await db.WorkOrder.AddAsync(value);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }


        // PUT api/WorkOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditWorkOrder(int id, int userId, [FromBody] WorkOrder value)
        {
            try
            {
                WorkOrder workOrder = await db.WorkOrder
                    .Include(x => x.ResponsibleUser)
                    .Include(x => x.WorkOrderStatus)
                    .SingleAsync(x => x.WorkOrderId == id);
                if(workOrder != null)
                {
                    workOrder.Name = value.Name;
                    workOrder.StartDate = value.StartDate;
                    workOrder.EndDate = value.EndDate;
                    workOrder.EstimatedEndDate = value.EstimatedEndDate;
                    workOrder.ResponsibleUserId = value.ResponsibleUserId;
                    workOrder.EstimatedEndDate = value.EstimatedEndDate;
                }
                string historyMessage = "WO-" + workOrder.Name + " был отредактирован";
                await HistoryWriter.WriteWorkOrderHistory(id, userId, historyMessage);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        [HttpDelete("{id}/Tools/{toolId}")]
        public async Task<IActionResult> RemoveToolFromWorkOrder(int workOrderId, int userId, int toolId, int statusId, [FromBody] string comment)
        {
            try
            {
                WorkOrderTool workOrderTool = await db.WorkOrderTool
                    .Include(x => x.Tool)
                    .Include(x => x.WorkOrder)
                    .SingleAsync(x => x.WorkOrderId == workOrderId && x.ToolId == toolId);
                if(workOrderTool != null)
                {
                    db.WorkOrderTool.Remove(workOrderTool);
                    Tool tool = await db.Tool
                        .Include(x => x.ToolStatus)
                        .SingleAsync(x => x.ToolId == toolId);
                    ToolStatus status = await db.ToolStatus.SingleAsync(x => x.ToolStatusId == statusId);
                    tool.ToolStatusId = statusId;
                    string workOrderHistoryMessage = "Инструмент " + tool.Name + "перенесён из сервиса в статус" + status.Name;
                    string toolHistoryMessage = "Инструмент изменил статус с " + tool.ToolStatus.Name + " на " + status.Name;
                    await HistoryWriter.WriteWorkOrderHistory(workOrderId, userId, workOrderHistoryMessage);
                    await HistoryWriter.WriteToolHistory(toolId, userId, statusId, toolHistoryMessage, comment: null);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // DELETE api/WorkOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkOrder(int id)
        {
            try
            {
                WorkOrder workOrder = await db.WorkOrder
                    .Include(x => x.WorkOrderTool)
                    .SingleAsync(x => x.WorkOrderId == id);
                if(workOrder != null)
                {
                    if(workOrder.WorkOrderTool.Any() == false)
                    {
                        db.WorkOrder.Remove(workOrder);
                    }
                    return Problem(statusCode: 412, detail: "Нельзя удалить сервис, к которому привязаны инструменты");
                }
                return Problem(statusCode: 412, detail: "Запись не найдена");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
    }
}
