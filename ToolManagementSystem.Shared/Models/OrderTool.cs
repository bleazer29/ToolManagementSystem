using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class OrderTool
    {
        public OrderTool()
        {
            OrderToolOperatingTime = new HashSet<OrderToolOperatingTime>();
        }

        public long OrderToolId { get; set; }
        public long OrderId { get; set; }
        public long ToolId { get; set; }
        public DateTime ArrivedDate { get; set; }
        public DateTime? LeftDate { get; set; }

        public virtual Order Order { get; set; }
        public virtual Tool Tool { get; set; }
        public virtual ICollection<OrderToolOperatingTime> OrderToolOperatingTime { get; set; }
    }
}
