using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class OrderHistory
    {
        public int OrderHistoryId { get; set; }
        public int OrderId { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatorId { get; set; }
        public string Message { get; set; }
        public int OrderStatusId { get; set; }

        public virtual User Creator { get; set; }
        public virtual Order Order { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
    }
}
