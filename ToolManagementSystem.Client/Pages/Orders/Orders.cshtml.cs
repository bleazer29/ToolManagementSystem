using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToolManagementSystem.Client.Managers;
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
        public int DeleteOrderId { get; set; }


        public async Task<IActionResult> OnGet()
        {
            Orders = await OrdersManager.GetOrdersAsync("", "", DateTime.MinValue, DateTime.MaxValue, "", "", "", "", "Name", true);
            Orders = Orders.OrderBy(x => x.Name).ToList();
            return Page();
        }
    }
}