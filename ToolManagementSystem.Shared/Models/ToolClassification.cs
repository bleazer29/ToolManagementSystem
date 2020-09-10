using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class ToolClassification
    {
        public ToolClassification()
        {
            InverseParentToolClassification = new HashSet<ToolClassification>();
            Tool = new HashSet<Tool>();
        }

        public int ToolClassificationId { get; set; }
        public string Name { get; set; }
        public int? ParentToolClassificationId { get; set; }

        public virtual ToolClassification ParentToolClassification { get; set; }
        public virtual ICollection<ToolClassification> InverseParentToolClassification { get; set; }
        public virtual ICollection<Tool> Tool { get; set; }
    }
}
