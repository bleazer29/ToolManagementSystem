using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class RolePermissionRight
    {
        public long RoleRightPermission { get; set; }
        public int RolePermissionId { get; set; }
        public int RightId { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatorId { get; set; }
        public DateTime? LastUpdate { get; set; }
        public int? LastUpdatorId { get; set; }

        public virtual User Creator { get; set; }
        public virtual User LastUpdator { get; set; }
        public virtual Right Right { get; set; }
        public virtual RolePermission RolePermission { get; set; }
    }
}
