using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class Document
    {
        public Document()
        {
            OrderDocument = new HashSet<OrderDocument>();
            ToolDocument = new HashSet<ToolDocument>();
            WorkOrderDocument = new HashSet<WorkOrderDocument>();
        }

        public int DocumentId { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string FileExtension { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual User Creator { get; set; }
        public virtual ICollection<OrderDocument> OrderDocument { get; set; }
        public virtual ICollection<ToolDocument> ToolDocument { get; set; }
        public virtual ICollection<WorkOrderDocument> WorkOrderDocument { get; set; }
    }
}
