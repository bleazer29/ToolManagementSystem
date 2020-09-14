using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class RepairTool
    {
        public int RepairToolId { get; set; }
        public int ToolId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public int UserId { get; set; }

        public virtual Tool Tool { get; set; }
        public virtual User User { get; set; }
    }
}
