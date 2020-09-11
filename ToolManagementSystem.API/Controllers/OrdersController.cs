using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolManagementSystem.API.Helpers;
using ToolManagementSystem.Shared.Models;
using ToolManagementSystem.Shared.RequestModels;

namespace ToolManagementSystem.API.Controllers
{

    [Route("api/Orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly TMSdbContext db;
        private HistoryWriter HistoryWriter;

        public OrdersController(TMSdbContext context)
        {
            db = context;
            HistoryWriter = new HistoryWriter();
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<IActionResult> GetOrders(string name, string status, 
            DateTime startDate, DateTime endDate, string wellId, string counterparty, string responsible, string contract)
        {
            try
            {
                List<Order> orders = await db.Order
                    .Include(x => x.Counterparty)
                    .Include(x => x.OrderStatus)
                    .Include(x => x.ResponsibleUser)
                    .Include(x => x.Well)
                    .ToListAsync();
                FilterOrders(orders, name, status, startDate, endDate, wellId, counterparty, responsible, contract);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        public List<Order> FilterOrders(List<Order> orders, string name, string status,
            DateTime startDate, DateTime endDate, string wellId, string counterparty, string responsible, string contract)
        {
            orders = FilterOrdersByStringParams(orders, name, status, wellId, counterparty, responsible, contract);
            orders = FilterOrdersByDate(orders, startDate, endDate);
            return orders;
        }

        public List<Order> FilterOrdersByStringParams(List<Order> orders, string name, string status,
            string wellId, string counterparty, string responsible, string contract)
        {

            if (string.IsNullOrEmpty(name) == false)
            {
                orders = orders.Where(x => x.Name.Contains(name)).ToList();
            }
            if (string.IsNullOrEmpty(status) == false)
            {
                orders = orders.Where(x => x.OrderStatus != null && x.OrderStatus.Name.Contains(status)).ToList();
            }
            if (string.IsNullOrEmpty(wellId) == false)
            {
                orders = orders.Where(x => x.Well != null && x.Well.Name.Contains(wellId)).ToList();
            }
            if (string.IsNullOrEmpty(counterparty) == false)
            {
                orders = orders.Where(x => x.Counterparty != null && x.Counterparty.Name.Contains(counterparty)).ToList();
            }
            if (string.IsNullOrEmpty(responsible) == false)
            {
                orders = orders.Where(x => x.ResponsibleUser != null && x.ResponsibleUser.Fio.Contains(responsible)).ToList();
            }
            if (string.IsNullOrEmpty(contract) == false)
            {
                orders = orders.Where(x => x.Contract != null && x.Contract.Name.Contains(contract)).ToList();
            }
            return orders;
        }

        public List<Order> FilterOrdersByDate(List<Order> orders, DateTime startDate, DateTime endDate)
        {
            if (startDate != null)
            {
                orders = orders.Where(x => x.StartDate >= startDate
                || x.EndDate >= startDate
                || x.EstimatedEndDate >= startDate).ToList();
            }
            if (endDate != null)
            {
                orders = orders.Where(x => x.StartDate >= endDate
                || x.EndDate >= endDate
                || x.EstimatedEndDate >= endDate).ToList();
            }
            return orders;
        }


        // GET api/Orders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            try
            {
                Order order = await db.Order
                        .Include(x => x.Counterparty)
                        .Include(x => x.OrderStatus)
                        .Include(x => x.ResponsibleUser)
                        .Include(x => x.Well)
                        .SingleAsync(x => x.OrderId == id);
                return Ok(order);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // POST api/Orders
        [HttpPost]
        public async Task<IActionResult> AddOrder(int userId, [FromBody] Order value)
        {
            try
            {
                await db.Order.AddAsync(value);
                await db.SaveChangesAsync();
                string historyMessage = "Наряд добавлен в базу";
                await HistoryWriter.WriteOrderHistory(userId, historyMessage);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // POST api/Orders/5/Tools/1
        [HttpPost("{id}/Tools/{toolId}")]
        public async Task<IActionResult> AddOperatingTime(int id, int toolId, [FromBody] OperatingTimeRequest request)
        {
            try
            {
                Order workOrder = await db.Order.SingleAsync(x => x.OrderId == id);
                if (workOrder != null)
                {
                    OrderToolOperatingTime orderToolOperatingTime = await db.OrderToolOperatingTime
                        .Include(x => x.OrderTool)
                        .SingleAsync(x => x.CreationDate == request.Date && x.OrderTool.OrderId == id && x.OrderTool.ToolId == toolId);
                    if (orderToolOperatingTime == null)
                    {
                        OrderToolOperatingTime newOrderToolOperatingTime =
                            await CreateNewOrderToolOperatingTime(id, toolId, request.OperatingTime, request.Date, request.Comment);
                        if (newOrderToolOperatingTime != null)
                        {
                            return Ok();
                        }
                    }
                    else
                    {
                        if (request.OperatingTime > 0)
                        {
                            orderToolOperatingTime.OperatingTime = request.OperatingTime;
                        }
                        if (string.IsNullOrEmpty(request.Comment))
                        {
                            orderToolOperatingTime.Commentary = request.Comment;
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

        // PUT api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditOrder(int id, int userId, [FromBody] Order value)
        {
            try
            {
                Order order = await db.Order
                    .Include(x => x.ResponsibleUser)
                    .Include(x => x.OrderStatus)
                    .SingleAsync(x => x.OrderId == id);
                if (order != null)
                {
                    order.Name = value.Name;
                    order.StartDate = value.StartDate;
                    order.EndDate = value.EndDate;
                    order.EstimatedEndDate = value.EstimatedEndDate;
                    order.ResponsibleUserId = value.ResponsibleUserId;
                    order.EstimatedEndDate = value.EstimatedEndDate;
                    order.WellId = value.WellId;
                }
                string historyMessage = "Наряд " + order.Name + " был отредактирован";
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

        //// POST api/Orders
        //[Route("api/Orders/{id}/Tools")]
        //[HttpPut]
        //public void EditOrderTools(int id, [FromBody] string value)
        //{
        //    Console.WriteLine("Called EditOrderTools(id, obj) method");
        //}

        // DELETE api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                Order order = await db.Order
                    .Include(x => x.OrderTool)
                    .SingleAsync(x => x.OrderId == id);
                if (order != null)
                {
                    if(order.OrderTool.Any() == false)
                    {
                        db.Order.Remove(order);
                        await db.SaveChangesAsync();
                    }
                    return Conflict();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
    }
}
