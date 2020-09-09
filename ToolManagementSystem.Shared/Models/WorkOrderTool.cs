using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class WorkOrderTool
    {
        public long WorkOrderToolId { get; set; }
        public long WorkOrderId { get; set; }
        public long ToolId { get; set; }
        public DateTime ArrivedDate { get; set; }
        public DateTime? LeftDate { get; set; }

        public virtual Tool Tool { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }
    }
}
