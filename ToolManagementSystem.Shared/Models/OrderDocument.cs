using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class OrderDocument
    {
        public long OrderDocumentId { get; set; }
        public long OrderId { get; set; }
        public long DocumentId { get; set; }

        public virtual Document Document { get; set; }
        public virtual Order Order { get; set; }
    }
}
