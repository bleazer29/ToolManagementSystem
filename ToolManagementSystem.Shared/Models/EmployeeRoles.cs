using System;
using System.Collections.Generic;
using System.Text;

namespace ToolManagementSystem.Shared.Models
{
    public class EmployeeRoles
    {
        public int EmployeeId { get; set; }
        public Employees Employe { get; set; }
        public int RoleId { get; set; }
        public Roles Role { get; set; }
    }
}
