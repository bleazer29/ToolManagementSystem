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
using ToolManagementSystem.Client.Managers.Maintenances;

namespace ToolManagementSystem.Client.Pages.Maintenances
{
    public class MaintenanceModel : PageModel
    {
        public List<WorkOrder> WorkOrders { get; set; } = new List<WorkOrder>();

        [BindProperty]
        public WorkOrder NewWorkOrder { get; set; } = new WorkOrder();

        [BindProperty]
        public WorkOrder EditWorkOrder { get; set; } = new WorkOrder();

        [BindProperty]
        public string filterByName { get; set; }

        [BindProperty]
        public string filterByStatus { get; set; }

        [BindProperty]
        public DateTime filterByStartDate { get; set; }

        [BindProperty]
        public DateTime filterByEndDate { get; set; }

        [BindProperty]
        public string filterByResponsible { get; set; }

        [BindProperty]
        public int DeleteWorkOrderId { get; set; }

        [BindProperty]
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGet()
        {
            WorkOrders = await WorkOrderManager.GetWorkOrdersAsync(filterByName, filterByStartDate, filterByEndDate, filterByResponsible,
                "Name", filterByStatus, true);
            if(WorkOrders != null)
            {
                return Page();
            }
            return RedirectToPage("/Error", new { ErrorMessage = "Не удалось получить данные из базы данных." });
        }
    }
}