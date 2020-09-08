using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class ToolStatus
    {
        public ToolStatus()
        {
            Tool = new HashSet<Tool>();
        }

        public long ToolStatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Tool> Tool { get; set; }
    }
}
