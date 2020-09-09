using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class ToolHistory
    {
        public long ToolHistoryId { get; set; }
        public long ToolId { get; set; }
        public long ToolStatusId { get; set; }
        public DateTime CreationDate { get; set; }
        public long CreatorId { get; set; }
        public string Message { get; set; }
        public string Commentary { get; set; }

        public virtual User Creator { get; set; }
        public virtual Tool Tool { get; set; }
    }
}
