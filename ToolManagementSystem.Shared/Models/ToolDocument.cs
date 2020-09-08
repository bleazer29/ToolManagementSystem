using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class ToolDocument
    {
        public long ToolDocumentId { get; set; }
        public long ToolId { get; set; }
        public long DocumentId { get; set; }

        public virtual Document Document { get; set; }
        public virtual Tool Tool { get; set; }
    }
}
