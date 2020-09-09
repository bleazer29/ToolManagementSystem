using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class Report
    {
        public Report()
        {
            ReportHistory = new HashSet<ReportHistory>();
        }

        public long ReportId { get; set; }
        public string Name { get; set; }
        public string FillePath { get; set; }

        public virtual ICollection<ReportHistory> ReportHistory { get; set; }
    }
}
