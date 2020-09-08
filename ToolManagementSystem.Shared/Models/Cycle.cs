using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class Cycle
    {
        public Cycle()
        {
            CycleItem = new HashSet<CycleItem>();
            Tool = new HashSet<Tool>();
        }

        public long CycleId { get; set; }
        public string Name { get; set; }
        public long CreatorId { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual User Creator { get; set; }
        public virtual ICollection<CycleItem> CycleItem { get; set; }
        public virtual ICollection<Tool> Tool { get; set; }
    }
}
