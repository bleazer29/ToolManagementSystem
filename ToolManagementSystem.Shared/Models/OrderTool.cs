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

        public int OrderToolId { get; set; }
        public int OrderId { get; set; }
        public int ToolId { get; set; }
        public DateTime ArrivedDate { get; set; }
        public DateTime? LeftDate { get; set; }

        public virtual Order Order { get; set; }
        public virtual Tool Tool { get; set; }
        public virtual ICollection<OrderToolOperatingTime> OrderToolOperatingTime { get; set; }
    }
}
