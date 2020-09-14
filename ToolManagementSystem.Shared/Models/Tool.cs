using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class Tool
    {
        public Tool()
        {
            OrderTool = new HashSet<OrderTool>();
            RepairTool = new HashSet<RepairTool>();
            ToolDocument = new HashSet<ToolDocument>();
            ToolHistory = new HashSet<ToolHistory>();
            WorkOrderTool = new HashSet<WorkOrderTool>();
        }

        public int ToolId { get; set; }
        public string Name { get; set; }
        public int NomenclatureId { get; set; }
        public int DepartmentId { get; set; }
        public string SerialNum { get; set; }
        public string PartNum { get; set; }
        public string VendorNum { get; set; }
        public int ToolStatusId { get; set; }
        public long MaxOperatingTime { get; set; }
        public long TotalOperatingTime { get; set; }
        public long CycleOperatingTime { get; set; }
        public int CycleId { get; set; }
        public int ToolClassificationId { get; set; }

        public virtual Cycle Cycle { get; set; }
        public virtual Department Department { get; set; }
        public virtual Nomenclature Nomenclature { get; set; }
        public virtual ToolClassification ToolClassification { get; set; }
        public virtual ToolStatus ToolStatus { get; set; }
        public virtual ICollection<OrderTool> OrderTool { get; set; }
        public virtual ICollection<RepairTool> RepairTool { get; set; }
        public virtual ICollection<ToolDocument> ToolDocument { get; set; }
        public virtual ICollection<ToolHistory> ToolHistory { get; set; }
        public virtual ICollection<WorkOrderTool> WorkOrderTool { get; set; }
    }
}
