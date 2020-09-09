using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class CycleItem
    {
        public long CycleItemId { get; set; }
        public long? PrevToolStatusId { get; set; }
        public long CurrToolStatusId { get; set; }
        public long? NextToolStatusId { get; set; }
        public long CycleId { get; set; }

        public virtual Cycle Cycle { get; set; }
    }
}
