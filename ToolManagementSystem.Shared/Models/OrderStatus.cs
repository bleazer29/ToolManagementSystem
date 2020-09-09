using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            Order = new HashSet<Order>();
            OrderHistory = new HashSet<OrderHistory>();
        }

        public long OrderStatusId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<OrderHistory> OrderHistory { get; set; }
    }
}
