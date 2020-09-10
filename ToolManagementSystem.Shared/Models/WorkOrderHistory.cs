using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class WorkOrderHistory
    {
        public int WorkOrderHistoryId { get; set; }
        public int WorkOrderId { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatorId { get; set; }
        public string Message { get; set; }
        public int WorkOrderStatusId { get; set; }

        public virtual User Creator { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }
        public virtual WorkOrderStatus WorkOrderStatus { get; set; }
    }
}
