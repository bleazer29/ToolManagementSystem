using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class RolePermissionRight
    {
        public long RoleRightPermission { get; set; }
        public long RolePermissionId { get; set; }
        public long RightId { get; set; }
        public DateTime CreationDate { get; set; }
        public long CreatorId { get; set; }
        public DateTime? LastUpdate { get; set; }
        public long? LastUpdatorId { get; set; }

        public virtual User Creator { get; set; }
        public virtual User LastUpdator { get; set; }
        public virtual Right Right { get; set; }
        public virtual RolePermission RolePermission { get; set; }
    }
}
