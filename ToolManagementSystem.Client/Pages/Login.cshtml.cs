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

        [BindProperty(SupportsGet =true)]
        public string Login { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Password { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostLogin()
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