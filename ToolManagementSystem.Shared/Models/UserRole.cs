using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class UserRole
    {
        public long UserRoleId { get; set; }
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public DateTime CreationDate { get; set; }
        public long CreatorId { get; set; }
        public DateTime? LastUpdate { get; set; }
        public long? LastUpdatorId { get; set; }

        public virtual User Creator { get; set; }
        public virtual User LastUpdator { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
