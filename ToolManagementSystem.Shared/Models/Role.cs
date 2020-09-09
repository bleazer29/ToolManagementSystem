using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class Role
    {
        public Role()
        {
            RolePermission = new HashSet<RolePermission>();
            UserRole = new HashSet<UserRole>();
        }

        public long RoleId { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public DateTime CreationDate { get; set; }
        public long CreatorId { get; set; }
        public DateTime? LastUpdate { get; set; }
        public long? LastUpdatorId { get; set; }

        public virtual User Creator { get; set; }
        public virtual User LastUpdator { get; set; }
        public virtual ICollection<RolePermission> RolePermission { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
