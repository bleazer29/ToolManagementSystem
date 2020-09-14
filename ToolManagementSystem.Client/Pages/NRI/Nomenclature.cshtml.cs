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
    public class NomenclatureModel : PageModel
    {
        public List<Nomenclature> Nomenclatures { get; set; } = new List<Nomenclature>();

        [BindProperty]
        public Nomenclature NewNomenclature { get; set; } = new Nomenclature();

        [BindProperty]
        public Nomenclature EditNomenclature { get; set; } = new Nomenclature();

        [BindProperty]
        public string filterByName { get; set; }
        [BindProperty]
        public string filterByVendorCode { get; set; }

        [BindProperty]
        public int DeleteNomenclatureId { get; set; }

        [BindProperty]
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Nomenclatures = await NomenclatureManager.GetNomenclaturesAsync(filterByName, "Name", true);
            if (Nomenclatures != null)
            {
                return Page();
            }
            else
                return RedirectToPage("/Error", new { ErrorMessage = "Не удалось получить данные из базы данных." });

        }

        public async Task<IActionResult> OnPostCreate()
        {
            ErrorMessage = "";
            HttpStatusCode temp = await NomenclatureManager.CreateNomenclatureAsync(NewNomenclature);
            if (temp != HttpStatusCode.OK)
            {
                //do something
                return RedirectToPage("/Error", new { ErrorMessage = "Не удалось добавить новую запись в базу данных." });
            }
            return RedirectToPage("Nomenclature");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            ErrorMessage = "";
            HttpStatusCode temp = await NomenclatureManager.DeleteNomenclatureAsync(DeleteNomenclatureId);
            if (temp != HttpStatusCode.OK)
            {
                //do something
                return RedirectToPage("/Error", new { ErrorMessage = "Не удалось удалить запись из базы данных." });
            }
            return RedirectToPage("Nomenclature");
        }

        public async Task<IActionResult> OnPostUpdate()
        {
            ErrorMessage = "";
            HttpStatusCode temp = await NomenclatureManager.UpdateNomenclatureAsync(EditNomenclature);
            if (temp != HttpStatusCode.OK)
            {
                //do something
                return RedirectToPage("/Error", new { ErrorMessage = "Не удалось обновить данные записи в базе данных." });
            }
            return RedirectToPage("Nomenclature");
        }

    }
}