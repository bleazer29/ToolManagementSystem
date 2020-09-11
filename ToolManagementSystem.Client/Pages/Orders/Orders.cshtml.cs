using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToolManagementSystem.Shared.Models;

namespace ToolManagementSystem.Client.Pages.Orders
{
    public class OrdersModel : PageModel
    {
        public List<Order> Orders { get; set; } = new List<Order>();

        [BindProperty]
        public Order NewOrder { get; set; } = new Order();

        [BindProperty]
        public Order EditOrder { get; set; } = new Order();

        [BindProperty]
        public string FilterByName { get; set; }
        [BindProperty]
        public string FilterByEDRPOU { get; set; }
        [BindProperty]
        public string FilterByAddress { get; set; }

        [BindProperty]
        public int DeleteOrderId { get; set; }


        public async Task<IActionResult> OnGet()
        {
            return null;
        }
    }
}