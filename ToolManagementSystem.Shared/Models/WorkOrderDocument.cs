using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class WorkOrderDocument
    {
        public int WorkOrderDocumentId { get; set; }
        public int WorkOrderId { get; set; }
        public int DocumentId { get; set; }

        public virtual Document Document { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }
    }
}
