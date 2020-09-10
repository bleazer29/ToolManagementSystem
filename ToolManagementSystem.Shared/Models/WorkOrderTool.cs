using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class WorkOrderTool
    {
        public int WorkOrderToolId { get; set; }
        public int WorkOrderId { get; set; }
        public int ToolId { get; set; }
        public DateTime ArrivedDate { get; set; }
        public DateTime? LeftDate { get; set; }

        public virtual Tool Tool { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }
    }
}
