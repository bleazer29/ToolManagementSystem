using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToolManagementSystem.Shared.Models;
using ToolManagementSystem.API;
using ToolManagementSystem.Client;
using ToolManagementSystem.Client.Managers.NRI;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;

namespace ToolManagementSystem.Client.Pages.NRI
{
    public class WellsModel : PageModel
    {
        public List<Well> Wells { get; set; } = new List<Well>();

        [BindProperty]
        public Well NewWell { get; set; } = new Well();

        [BindProperty]
        public Well EditWell { get; set; } = new Well();

        [BindProperty]
        public string filterByName { get; set; }
        [BindProperty]
        public string filterByAddress { get; set; }
        [BindProperty]
        public string filterByWellNumber { get; set; }

        [BindProperty]
        public int DeleteWellId { get; set; }

        [BindProperty]
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Wells = await WellsManager.GetWellsAsync(filterByName, filterByAddress, /*filterByWellNumber,*/  "Name", true);
            if (Wells != null)
            {
                Wells = Wells.OrderBy(x => x.Name).ToList();
                return Page();
            }
            else
                return RedirectToPage("/Error", new { ErrorMessage = "Не удалось получить данные из базы данных." });

        }

        public async Task<IActionResult> OnPostCreate()
        {
            ErrorMessage = "";
            HttpStatusCode temp = await WellsManager.CreateWellAsync(NewWell);
            if (temp != HttpStatusCode.OK)
            {
                //do something
                return RedirectToPage("/Error", new { ErrorMessage = "Не удалось добавить новую запись в базу данных." });
            }
            return RedirectToPage("Wells");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            ErrorMessage = "";
            HttpStatusCode temp = await WellsManager.DeleteWellAsync(DeleteWellId);
            if (temp != HttpStatusCode.OK)
            {
                //do something
                return RedirectToPage("/Error", new { ErrorMessage = "Не удалось удалить запись из базы данных." });
            }
            return RedirectToPage("Wells");
        }

        public async Task<IActionResult> OnPostUpdate()
        {
            ErrorMessage = "";
            HttpStatusCode temp = await WellsManager.UpdateWellAsync(EditWell);
            if (temp != HttpStatusCode.OK)
            {
                //do something
                return RedirectToPage("/Error", new { ErrorMessage = "Не удалось обновить данные записи в базе данных." });
            }
            return RedirectToPage("Wells");
        }
    }
}