﻿using System;
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
    public class CounterpartiesModel : PageModel
    {
        public List<Counterparty> Counterparties { get; set; } = new List<Counterparty>();

        [BindProperty]
        public Counterparty NewCounterparty { get; set; } = new Counterparty();

        [BindProperty]
        public Counterparty EditCounterparty { get; set; } = new Counterparty();

        [BindProperty]
        public string filterByName { get; set; }
        [BindProperty]
        public string filterByEDRPOU { get; set; }
        [BindProperty]
        public string filterByAddress { get; set; }

        [BindProperty]
        public int DeleteCounterpartyId { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Counterparties = await CounterpartiesManager.GetCounterpartiesAsync(filterByName, filterByEDRPOU, filterByAddress, "Name", true);
            Counterparties = Counterparties.OrderBy(x => x.Name).ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostCounterparty()
        {
            HttpStatusCode temp = await CounterpartiesManager.CreateCounterpartyAsync(NewCounterparty);
            if (temp != HttpStatusCode.OK)
            {
                //do something

            }
            return RedirectToPage("Counterparties");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            HttpStatusCode temp = await CounterpartiesManager.DeleteCounterpartyAsync(DeleteCounterpartyId);
            if (temp != HttpStatusCode.OK)
            {
                //do something
            }
            return RedirectToPage("Counterparties");
        }

        public async Task<IActionResult> OnPostUpdate()
        {
            HttpStatusCode temp = await CounterpartiesManager.UpdateCounterpartyAsync(EditCounterparty);
            if (temp != HttpStatusCode.OK)
            {
                //do something
            }
            return RedirectToPage("Counterparties");
            
        }
    }
}