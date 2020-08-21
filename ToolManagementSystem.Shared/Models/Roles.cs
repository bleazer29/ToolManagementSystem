﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ToolManagementSystem.Shared.Models
{
    public class Roles
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        [NotMapped]
        public IList<EmployeeRoles> EmployeeRoles { get; set; }
        [NotMapped]
        public IList<RolesPages> RolesPages { get; set; }
    }
}
