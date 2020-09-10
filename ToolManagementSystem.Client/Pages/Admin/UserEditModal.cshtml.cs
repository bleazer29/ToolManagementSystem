using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ToolManagementSystem.Client.Pages.Admin
{
    public class UserEditModalModel : PageModel
    {
        public string test { get; set; }
        public void OnGet()
        {
        }
        public PartialViewResult OnGetPartialUserEdit()
        {
           
            return Partial("UserEditModal", this);
        }

        
    }
}