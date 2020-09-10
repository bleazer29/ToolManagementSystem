using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class RolePermission
    {
        public RolePermission()
        {
            RolePermissionRight = new HashSet<RolePermissionRight>();
        }

        public int RolePermissionId { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatorId { get; set; }
        public DateTime? LastUpdate { get; set; }
        public int? LastUpdatorId { get; set; }

        public virtual User Creator { get; set; }
        public virtual User LastUpdator { get; set; }
        public virtual Permission Permission { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<RolePermissionRight> RolePermissionRight { get; set; }
    }
}
