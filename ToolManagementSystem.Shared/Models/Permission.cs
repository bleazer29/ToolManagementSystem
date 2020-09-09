using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class Permission
    {
        public Permission()
        {
            InverseParentPermission = new HashSet<Permission>();
            RolePermission = new HashSet<RolePermission>();
        }

        public long PermissionId { get; set; }
        public string Name { get; set; }
        public string ViewName { get; set; }
        public string Alias { get; set; }
        public int? OrderNo { get; set; }
        public long? ParentPermissionId { get; set; }

        public virtual Permission ParentPermission { get; set; }
        public virtual ICollection<Permission> InverseParentPermission { get; set; }
        public virtual ICollection<RolePermission> RolePermission { get; set; }
    }
}
