using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class OrderDocument
    {
        public int OrderDocumentId { get; set; }
        public int OrderId { get; set; }
        public int DocumentId { get; set; }

        public virtual Document Document { get; set; }
        public virtual Order Order { get; set; }
    }
}
