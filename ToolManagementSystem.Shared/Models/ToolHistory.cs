using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class ToolHistory
    {
        public int ToolHistoryId { get; set; }
        public int ToolId { get; set; }
        public int ToolStatusId { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatorId { get; set; }
        public string Message { get; set; }
        public string Commentary { get; set; }

        public virtual User Creator { get; set; }
        public virtual Tool Tool { get; set; }
    }
}
