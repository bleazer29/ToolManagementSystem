using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class WorkOrderStatus
    {
        public WorkOrderStatus()
        {
            WorkOrder = new HashSet<WorkOrder>();
            WorkOrderHistory = new HashSet<WorkOrderHistory>();
        }

        public long WorkOrderStatusId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<WorkOrder> WorkOrder { get; set; }
        public virtual ICollection<WorkOrderHistory> WorkOrderHistory { get; set; }
    }
}
