using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class Department
    {
        public Department()
        {
            Tool = new HashSet<Tool>();
            User = new HashSet<User>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Tool> Tool { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
