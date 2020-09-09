using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class OrderToolOperatingTime
    {
        public long OrderToolOperatingTimeId { get; set; }
        public long OrderToolId { get; set; }
        public long ToolStatusId { get; set; }
        public string Commentary { get; set; }
        public long OperatingTime { get; set; }
        public long CreatorId { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual User Creator { get; set; }
        public virtual OrderTool OrderTool { get; set; }
    }
}
