using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDocument = new HashSet<OrderDocument>();
            OrderHistory = new HashSet<OrderHistory>();
            OrderTool = new HashSet<OrderTool>();
        }

        public int OrderId { get; set; }
        public int ContractId { get; set; }
        public int WellId { get; set; }
        public int CounterpartyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public int CreatorId { get; set; }
        public int OrderStatusId { get; set; }
        public string Name { get; set; }
        public int? ResponsibleUserId { get; set; }

        public virtual Contract Contract { get; set; }
        public virtual Counterparty Counterparty { get; set; }
        public virtual User Creator { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual User ResponsibleUser { get; set; }
        public virtual Well Well { get; set; }
        public virtual ICollection<OrderDocument> OrderDocument { get; set; }
        public virtual ICollection<OrderHistory> OrderHistory { get; set; }
        public virtual ICollection<OrderTool> OrderTool { get; set; }
    }
}
