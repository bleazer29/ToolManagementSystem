using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class OrderToolOperatingTime
    {
        public int OrderToolOperatingTimeId { get; set; }
        public int OrderToolId { get; set; }
        public int ToolStatusId { get; set; }
        public string Commentary { get; set; }
        public long OperatingTime { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual User Creator { get; set; }
        public virtual OrderTool OrderTool { get; set; }
    }
}
