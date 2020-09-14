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
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnGetUser(string login, string password)
        {
            await AccountManager.LoginAsync(login, password);
            return RedirectToPage("Index");
        }
    }
}