using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class Counterparty
    {
        public Counterparty()
        {
            Contract = new HashSet<Contract>();
            Order = new HashSet<Order>();
            Well = new HashSet<Well>();
        }

        public long CounterpartyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Edrpou { get; set; }

        public virtual ICollection<Contract> Contract { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Well> Well { get; set; }
    }
}
