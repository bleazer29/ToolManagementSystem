using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class OrderHistory
    {
        public long OrderHistoryId { get; set; }
        public long OrderId { get; set; }
        public DateTime CreationDate { get; set; }
        public long CreatorId { get; set; }
        public string Message { get; set; }
        public long OrderStatusId { get; set; }

        public virtual User Creator { get; set; }
        public virtual Order Order { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
    }
}
