using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class CycleItem
    {
        public int CycleItemId { get; set; }
        public int? PrevToolStatusId { get; set; }
        public int CurrToolStatusId { get; set; }
        public int? NextToolStatusId { get; set; }
        public int CycleId { get; set; }

        public virtual Cycle Cycle { get; set; }
    }
}
