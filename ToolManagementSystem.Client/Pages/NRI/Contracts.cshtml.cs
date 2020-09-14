using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToolManagementSystem.Client.Managers;
using ToolManagementSystem.Client.Managers.NRI;
using ToolManagementSystem.Shared.Models;

namespace ToolManagementSystem.Client.Pages.NRI
{
    public class ContractsModel : PageModel
    {
        public List<Contract> Contracts { get; set; } = new List<Contract>();

        [BindProperty]
        public Contract NewContract { get; set; } = new Contract();

        [BindProperty]
        public Contract EditContract { get; set; } = new Contract();

        [BindProperty]
        public string filterByName{ get; set; }
        [BindProperty]
        public DateTime filterByDateStart { get; set; }
        [BindProperty]
        public DateTime filterByDateEnd { get; set; }
        [BindProperty]
        public string filterByCounterparty { get; set; }
        [BindProperty]
        public int DeleteContractId { get; set; }
        [BindProperty]
        public string ErrorMessage { get; set; }
       
        public SelectList CounterpartiesList { get; set; }

        public async Task<IActionResult> OnGet()
        {
            filterByDateStart = DateTime.Now.AddMonths(-1);
            filterByDateEnd = DateTime.Now.AddMonths(1); ;
            Contracts = await ContractsManager.GetContractsAsync(filterByName, filterByDateStart, filterByDateEnd, filterByCounterparty, "Name", true);
            List<Counterparty> counterparties = await CounterpartiesManager.GetCounterpartiesAsync("", "","", "Name", true);
            if (counterparties != null) CounterpartiesList = new SelectList(counterparties, nameof(Counterparty.CounterpartyId), nameof(Counterparty.Name));
           
            NewContract.DateStart = DateTime.Now;
            NewContract.DateEnd = DateTime.Now.AddDays(1);
            NewContract.CounterpartyId=null;
            if (Contracts != null)
            {
                return Page();
            }
            else
                return RedirectToPage("/Error", new { ErrorMessage = "Не удалось получить данные из базы данных." });

        }

        public async Task<IActionResult> OnPostCreate()
        {
            ErrorMessage = "";
            HttpStatusCode temp = await ContractsManager.CreateContractAsync(NewContract);
            if (temp != HttpStatusCode.OK)
            {
                //do something
                return RedirectToPage("/Error", new { ErrorMessage = "Не удалось добавить новую запись в базу данных." });
            }
            return RedirectToPage("Contracts");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            ErrorMessage = "";
            HttpStatusCode temp = await ContractsManager.DeleteContractAsync(DeleteContractId);
            if (temp != HttpStatusCode.OK)
            {
                //do something
                return RedirectToPage("/Error", new { ErrorMessage = "Не удалось удалить запись из базы данных." });
            }
            return RedirectToPage("Contracts");
        }

        public async Task<IActionResult> OnPostUpdate()
        {
            ErrorMessage = "";
            HttpStatusCode temp = await ContractsManager.UpdateContractAsync(EditContract);
            if (temp != HttpStatusCode.OK)
            {
                //do something
                return RedirectToPage("/Error", new { ErrorMessage = "Не удалось обновить данные записи в базе данных." });
            }
            return RedirectToPage("Contracts");
        }

    }
}