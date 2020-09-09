using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class WorkOrderHistory
    {
        public long WorkOrderHistoryId { get; set; }
        public long WorkOrderId { get; set; }
        public DateTime CreationDate { get; set; }
        public long CreatorId { get; set; }
        public string Message { get; set; }
        public long WorkOrderStatusId { get; set; }

        public virtual User Creator { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }
        public virtual WorkOrderStatus WorkOrderStatus { get; set; }
    }
}
