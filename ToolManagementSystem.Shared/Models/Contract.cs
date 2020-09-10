﻿using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class Contract
    {
        public Contract()
        {
            Order = new HashSet<Order>();
        }

        public int ContractId { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int? CounterpartyId { get; set; }

        public virtual Counterparty Counterparty { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
