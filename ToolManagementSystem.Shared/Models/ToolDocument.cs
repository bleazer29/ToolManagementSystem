using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class ToolDocument
    {
        public int ToolDocumentId { get; set; }
        public int ToolId { get; set; }
        public int DocumentId { get; set; }

        public virtual Document Document { get; set; }
        public virtual Tool Tool { get; set; }
    }
}
