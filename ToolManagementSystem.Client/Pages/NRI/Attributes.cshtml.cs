using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToolManagementSystem.Client;
using ToolManagementSystem.Shared.Models;
using ToolManagementSystem.API;
using ToolManagementSystem.Client.Managers.NRI;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;

namespace ToolManagementSystem.Client.Pages.NRI
{
    public class AttributesModel : PageModel
    {
        public List<Specification> Specifications { get; set; } = new List<Specification>();

        [BindProperty]
        public Specification NewSpecification { get; set; } = new Specification();

        [BindProperty]
        public Specification EditSpecification { get; set; } = new Specification();

        [BindProperty]
        public string filterByName { get; set; }

        [BindProperty]
        public int DeleteSpecificationId { get; set; }

        [BindProperty]
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Specifications = await SpecificationsManager.GetSpecificationsAsync(filterByName, "Name", true);
            if (Specifications != null)
            {
                Specifications = Specifications.OrderBy(x => x.Name).ToList();
                return Page();
            }
            else
                return RedirectToPage("/Error", new { ErrorMessage = "Не удалось получить данные из базы данных." });

        }

        public async Task<IActionResult> OnPostCreate()
        {
            ErrorMessage = "";
            HttpStatusCode temp = await SpecificationsManager.CreateSpecificationAsync(NewSpecification);
            if (temp != HttpStatusCode.OK)
            {
                //do something
                return RedirectToPage("/Error", new { ErrorMessage = "Не удалось добавить новую запись в базу данных." });
            }
            return RedirectToPage("Attributes");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            ErrorMessage = "";
            HttpStatusCode temp = await SpecificationsManager.DeleteSpecificationAsync(DeleteSpecificationId);
            if (temp != HttpStatusCode.OK)
            {
                //do something
                return RedirectToPage("/Error", new { ErrorMessage = "Не удалось удалить запись из базы данных." });
            }
            return RedirectToPage("Attributes");
        }

        public async Task<IActionResult> OnPostUpdate()
        {
            ErrorMessage = "";
            HttpStatusCode temp = await SpecificationsManager.UpdateSpecificationAsync(EditSpecification);
            if (temp != HttpStatusCode.OK)
            {
                //do something
                return RedirectToPage("/Error", new { ErrorMessage = "Не удалось обновить данные записи в базе данных." });
            }
            return RedirectToPage("Attributes");
        }
    }
}