using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ToolManagementSystem.Shared.Models
{
    public class EmployeeRoles
    {
        public int EmployeeId { get; set; }
        [NotMapped]
        public Employees Employe { get; set; }
        public int RoleId { get; set; }
        [NotMapped]
        public Roles Role { get; set; }
        //public bool IsSelected { get; set; }

    }
}
