using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolManagementSystem.Shared.Models;

namespace ToolManagementSystem.API.Helpers
{
    public class HistoryWriter
    {

        private readonly TMSdbContext db;

        public async Task WriteToolHistory(int toolId, int userId, int toolStatusId, string message, string comment)
        {
            try
            {
                ToolHistory history = new ToolHistory();
                history.ToolId = toolId;
                history.Message = message;
                history.Commentary = comment;
                history.CreationDate = DateTime.UtcNow;
                history.CreatorId = userId;
                history.ToolStatusId = toolStatusId;
                await db.ToolHistory.AddAsync(history);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task WriteOrderHistory(int userId, string message, int toolStatusId = 0, int toolId = 0, string comment = null)
        {
            try
            {
                ToolHistory history = new ToolHistory();
                if(toolId != 0)
                {
                    history.ToolId = toolId;
                }
                history.Message = message;
                history.Commentary = comment;
                history.CreationDate = DateTime.UtcNow;
                history.CreatorId = userId;
                if(toolStatusId != 0)
                {
                    history.ToolStatusId = toolStatusId;
                }
                await db.ToolHistory.AddAsync(history);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task WriteWorkOrderHistory(int workOrderId, int userId, string message)
        {
            try
            {
                WorkOrderHistory history = new WorkOrderHistory();
                history.WorkOrderId = workOrderId;
                history.Message = message;
                history.CreationDate = DateTime.UtcNow;
                history.CreatorId = userId;
                await db.WorkOrderHistory.AddAsync(history);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
