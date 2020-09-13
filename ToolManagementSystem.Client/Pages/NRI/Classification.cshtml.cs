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
    public class ClassificationModel : PageModel
    {
        public List<ToolClassification> Classifications { get; set; } = new List<ToolClassification>();

        [BindProperty]
        public ToolClassification NewClassification { get; set; } = new ToolClassification();

        [BindProperty]
        public ToolClassification EditClassification { get; set; } = new ToolClassification();

        [BindProperty]
        public string filterByName { get; set; }

        [BindProperty]
        public int DeleteClassificationId { get; set; }

        [BindProperty]
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Classifications = await ClassificationManager.GetClassificationsAsync(filterByName, "Name", true);
            if (Classifications != null)
            {
                Classifications = Classifications.OrderBy(x => x.Name).ToList();
                return Page();
            }
            else
                return RedirectToPage("/Error", new { ErrorMessage = "Не удалось получить данные из базы данных." });

        }

        public async Task<IActionResult> OnPostCreate()
        {
            ErrorMessage = "";
            HttpStatusCode temp = await ClassificationManager.CreateClassificationAsync(NewClassification);
            if (temp != HttpStatusCode.OK)
            {
                //do something
                return RedirectToPage("/Error", new { ErrorMessage = "Не удалось добавить новую запись в базу данных." });
            }
            return RedirectToPage("Classifications");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            ErrorMessage = "";
            HttpStatusCode temp = await ClassificationManager.DeleteClassificationAsync(DeleteClassificationId);
            if (temp != HttpStatusCode.OK)
            {
                //do something
                return RedirectToPage("/Error", new { ErrorMessage = "Не удалось удалить запись из базы данных." });
            }
            return RedirectToPage("Classifications");
        }

        public async Task<IActionResult> OnPostUpdate()
        {
            ErrorMessage = "";
            HttpStatusCode temp = await ClassificationManager.UpdateClassificationAsync(EditClassification);
            if (temp != HttpStatusCode.OK)
            {
                //do something
                return RedirectToPage("/Error", new { ErrorMessage = "Не удалось обновить данные записи в базе данных." });
            }
            return RedirectToPage("Classifications");
        }
    }
}