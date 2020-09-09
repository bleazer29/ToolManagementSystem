using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class ReportHistory
    {
        public long ReportHistoryId { get; set; }
        public string Name { get; set; }
        public long CreatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public long ReportId { get; set; }

        public virtual User Creator { get; set; }
        public virtual Report Report { get; set; }
    }
}
