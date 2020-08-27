using System;
using System.Collections.Generic;
using System.Text;

namespace ToolManagementSystem.Shared.Models
{
    public class RolesPages
    {
        public int RoleId { get; set; }
        public Roles Roles { get; set; }
        public int PagesId { get; set; }
        public Pages Pages { get; set; }
        //public bool IsVisible { get; set; }
    }
}
