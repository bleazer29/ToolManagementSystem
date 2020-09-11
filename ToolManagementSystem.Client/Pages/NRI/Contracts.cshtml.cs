using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToolManagementSystem.Client.Managers;
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
        public string FilterByNumber{ get; set; }

        [BindProperty]
        public int DeleteContractId { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Contracts = await ContractsManager.GetContractsAsync(FilterByNumber);
            return RedirectToPage("Contracts");
        }

        public void OnGetContract(int id)
        {
            EditContract = ContractsManager.GetContractAsync(id).Result;
            if (EditContract.ContractId == -1)
            {
                //do something
            }
        }

        public async Task<IActionResult> OnPostContract()
        {
            Contract temp = await ContractsManager.CreateContractAsync(NewContract);
            if (temp != null)
            {
                await ContractsManager.CreateContractAsync(temp);
            }
            return await OnGet();
        }

        public async Task<IActionResult> OnPostDelete()
        {
            HttpStatusCode temp = await ContractsManager.DeleteContractAsync(DeleteContractId);
            if (temp != HttpStatusCode.OK)
            {
                //do something
            }
            return await OnGet();
        }

        public async Task<IActionResult> OnPostUpdate()
        {
            Contract temp = await ContractsManager.UpdateContractAsync(EditContract);
            if (temp != null)
            {
                if (temp.ContractId == -1)
                {
                    //do something
                }
            }
            return await OnGet();
        }

    }
}