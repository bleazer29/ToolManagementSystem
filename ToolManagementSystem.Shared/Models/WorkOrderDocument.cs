using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class WorkOrderDocument
    {
        public long WorkOrderDocumentId { get; set; }
        public long WorkOrderId { get; set; }
        public long DocumentId { get; set; }

        public virtual Document Document { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }
    }
}
