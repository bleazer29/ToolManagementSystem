using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class Right
    {
        public Right()
        {
            RolePermissionRight = new HashSet<RolePermissionRight>();
        }

        public long RightId { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }

        public virtual ICollection<RolePermissionRight> RolePermissionRight { get; set; }
    }
}
