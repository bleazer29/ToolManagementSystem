using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class Well
    {
        public Well()
        {
            Order = new HashSet<Order>();
        }

        public long WellId { get; set; }
        public string Name { get; set; }
        public long? CounterpartyId { get; set; }
        public string Address { get; set; }

        public virtual Counterparty Counterparty { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
