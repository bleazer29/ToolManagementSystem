using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class Tool
    {
        public Tool()
        {
            OrderTool = new HashSet<OrderTool>();
            ToolDocument = new HashSet<ToolDocument>();
            ToolHistory = new HashSet<ToolHistory>();
            WorkOrderTool = new HashSet<WorkOrderTool>();
        }

        public long ToolId { get; set; }
        public string Name { get; set; }
        public long NomenclatureId { get; set; }
        public long DepartmentId { get; set; }
        public string SerialNum { get; set; }
        public string PartNum { get; set; }
        public string VendorNum { get; set; }
        public long ToolStatusId { get; set; }
        public long MaxOperatingTime { get; set; }
        public long TotalOperatingTime { get; set; }
        public long CycleOperatingTime { get; set; }
        public long CycleId { get; set; }
        public long ToolClassificationId { get; set; }

        public virtual Cycle Cycle { get; set; }
        public virtual Department Department { get; set; }
        public virtual Nomenclature Nomenclature { get; set; }
        public virtual ToolClassification ToolClassification { get; set; }
        public virtual ToolStatus ToolStatus { get; set; }
        public virtual ICollection<OrderTool> OrderTool { get; set; }
        public virtual ICollection<ToolDocument> ToolDocument { get; set; }
        public virtual ICollection<ToolHistory> ToolHistory { get; set; }
        public virtual ICollection<WorkOrderTool> WorkOrderTool { get; set; }
    }
}
