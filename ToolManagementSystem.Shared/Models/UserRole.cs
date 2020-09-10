using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class UserRole
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatorId { get; set; }
        public DateTime? LastUpdate { get; set; }
        public int? LastUpdatorId { get; set; }

        public virtual User Creator { get; set; }
        public virtual User LastUpdator { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
