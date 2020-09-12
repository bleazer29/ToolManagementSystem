using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToolManagementSystem.Client.Managers.NRI;
using ToolManagementSystem.Shared.Models;

namespace ToolManagementSystem.Client.Pages.NRI
{
    public class StatusesModel : PageModel
    {
        public List<ToolStatus> Statuses { get; set; } = new List<ToolStatus>();

        [BindProperty]
        public ToolStatus NewStatus { get; set; } = new ToolStatus();

        [BindProperty]
        public ToolStatus EditStatus { get; set; } = new ToolStatus();

        [BindProperty]
        public string filterByName { get; set; }

        [BindProperty]
        public int DeleteStatusId { get; set; }

        [BindProperty]
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Statuses = await ToolStatusesManager.GetToolStatusesAsync(filterByName, "Name", true);
            if (Statuses != null)
            {
                Statuses = Statuses.OrderBy(x => x.Name).ToList();
                return Page();
            }
            else
                return RedirectToPage("/Error", new { ErrorMessage = "Не удалось получить данные из базы данных." });

        }

        public async Task<IActionResult> OnPostCreate()
        {
            ErrorMessage = "";
            HttpStatusCode temp = await ToolStatusesManager.CreateToolStatusAsync(NewStatus);
            if (temp != HttpStatusCode.OK)
            {
                //do something
                return RedirectToPage("/Error", new { ErrorMessage = "Не удалось добавить новую запись в базу данных." });
            }
            return RedirectToPage("Statuses");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            ErrorMessage = "";
            HttpStatusCode temp = await ToolStatusesManager.DeleteToolStatusAsync(DeleteStatusId);
            if (temp != HttpStatusCode.OK)
            {
                //do something
                return RedirectToPage("/Error", new { ErrorMessage = "Не удалось удалить запись из базы данных." });
            }
            return RedirectToPage("Statuses");
        }

        public async Task<IActionResult> OnPostUpdate()
        {
            ErrorMessage = "";
            HttpStatusCode temp = await ToolStatusesManager.UpdateToolStatusAsync(EditStatus);
            if (temp != HttpStatusCode.OK)
            {
                //do something
                return RedirectToPage("/Error", new { ErrorMessage = "Не удалось обновить данные записи в базе данных." });
            }
            return RedirectToPage("Statuses");
        }
    }
}