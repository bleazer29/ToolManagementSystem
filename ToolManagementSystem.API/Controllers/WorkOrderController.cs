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
    [Route("api/WorkOrders")]
    [ApiController]
    public class WorkOrderController : ControllerBase
    {
        private readonly TMSdbContext db;

        public WorkOrderController(TMSdbContext context)
        {
            db = context;
        }

        // GET: api/WorkOrders
        [HttpGet("{startdate:datetime?}/{enddate:datetime?}/{status?}")]
        public async Task<IActionResult> GetWorkOrders(DateTime startdate, DateTime enddate, string name, string responsible, string status)
        {
            try
            {
                List<WorkOrder> workOrders = await db.WorkOrder
                    .Include(x => x.ResponsibleUser)
                    .Include(x => x.WorkOrderStatus)
                    .ToListAsync();
                if (string.IsNullOrEmpty(name) == false)
                {
                    workOrders = workOrders.Where(x => x.Name.Contains(name)).ToList();
                }
                if (string.IsNullOrEmpty(responsible) == false)
                {
                    workOrders = workOrders.Where(x => x.ResponsibleUser.Fio.Contains(responsible)).ToList();
                }
                if (string.IsNullOrEmpty(status) == false)
                {
                    workOrders = workOrders.Where(x => x.WorkOrderStatus.Name.Contains(status)).ToList();
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

        // POST api/WorkOrders/5/Tools/1
        [HttpPost("{id}/Tools/{toolId}")]
        public async Task<IActionResult> AddOperatingTime(int id, int toolId, DateTime date,
            long operatingTime, [FromBody] string comment)
        {
            try
            {
                WorkOrder workOrder = await db.WorkOrder.SingleAsync(x => x.WorkOrderId == id);
                if (workOrder != null)
                {
                    OrderToolOperatingTime orderToolOperatingTime = await db.OrderToolOperatingTime
                        .Include(x => x.OrderTool)
                        .SingleAsync(x => x.CreationDate == date && x.OrderTool.OrderId == id && x.OrderTool.ToolId == toolId);
                    if (orderToolOperatingTime == null)
                    {
                        OrderToolOperatingTime newOrderToolOperatingTime = 
                            await CreateNewOrderToolOperatingTime(id, toolId, operatingTime, date, comment);
                        if(newOrderToolOperatingTime != null)
                        {
                            return Ok();
                        }
                    }
                    else
                    {
                        if(operatingTime > 0)
                        {
                            orderToolOperatingTime.OperatingTime = operatingTime;
                        }
                        if (string.IsNullOrEmpty(comment))
                        {
                            orderToolOperatingTime.Commentary = comment;
                        }
                        await db.SaveChangesAsync();
                        return Ok();
                    }
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
        
        public async Task<OrderToolOperatingTime> CreateNewOrderToolOperatingTime(int orderId, int toolId, long operatingTime, DateTime date, string comment)
        {
            try
            {
                OrderToolOperatingTime newOrderToolOperatingTime = new OrderToolOperatingTime();
                if (operatingTime > 0)
                {
                    newOrderToolOperatingTime.OperatingTime = operatingTime;
                }
                else
                {
                    throw new ArgumentException("Invalid operating time");
                }
                OrderTool tool = await db.OrderTool.SingleAsync(x => x.ToolId == toolId && x.OrderId == orderId);
                newOrderToolOperatingTime.OrderToolId = tool.OrderToolId;
                newOrderToolOperatingTime.CreationDate = date;
                if (string.IsNullOrEmpty(comment))
                {
                    newOrderToolOperatingTime.Commentary = comment;
                }
                await db.AddAsync(newOrderToolOperatingTime);
                await db.SaveChangesAsync();
                return newOrderToolOperatingTime;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // PUT api/WorkOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditWorkOrder(int id, [FromBody] WorkOrder value)
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
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // DELETE api/WorkOrders/5
        [HttpDelete("{id}")]
        public void DeleteWorkOrder(int id)
        {
            Console.WriteLine("Called DeleteMaintenance(id) method");
        }
    }
}
