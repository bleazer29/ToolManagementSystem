using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToolManagementSystem.Client.Managers;

namespace ToolManagementSystem.Client.Pages
{
    public class LoginModel : PageModel
    {

        [BindProperty]
        public string Login { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnGetUser()
        {
            await AccountManager.LoginAsync(Login, Password);
            if(AccountManager.CurrentUser != null)
            {
                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage("Login");
            }
        }
    }
}