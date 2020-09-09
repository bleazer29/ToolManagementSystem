using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class WorkOrder
    {
        public WorkOrder()
        {
            WorkOrderDocument = new HashSet<WorkOrderDocument>();
            WorkOrderHistory = new HashSet<WorkOrderHistory>();
            WorkOrderTool = new HashSet<WorkOrderTool>();
        }

        public long WorkOrderId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public long CreatorId { get; set; }
        public long WorkOrderStatusId { get; set; }
        public string Name { get; set; }
        public long? ResponsibleUserId { get; set; }

        public virtual User Creator { get; set; }
        public virtual User ResponsibleUser { get; set; }
        public virtual WorkOrderStatus WorkOrderStatus { get; set; }
        public virtual ICollection<WorkOrderDocument> WorkOrderDocument { get; set; }
        public virtual ICollection<WorkOrderHistory> WorkOrderHistory { get; set; }
        public virtual ICollection<WorkOrderTool> WorkOrderTool { get; set; }
    }
}
