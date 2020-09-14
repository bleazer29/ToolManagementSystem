using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ToolManagementSystem.Shared.Models;

namespace ToolManagementSystem.Client.Managers.Maintenances
{
    public class WorkOrderManager
    {
        static string apiControllerName { get; set; } = "WorkOrders";
        public async static Task<List<WorkOrder>> GetWorkOrdersAsync(string filterByName, DateTime filterByDateStart, DateTime filterByDateEnd,
            string filterByResponsibleName, string sortField, string filterByStatus, bool isAscendingSort)
        {
            List<WorkOrder> workOrders = null;
            try
            {
                string requestAddress = "/" + filterByDateStart.ToString("yyyy-MM-dd") + "/" + filterByDateEnd.ToString("yyyy-MM-dd") + "?name="
                    + filterByName + "&responsible=" + filterByResponsibleName + "&status=" + filterByStatus;
                HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName + requestAddress);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    workOrders = JsonConvert.DeserializeObject<List<WorkOrder>>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            workOrders = SortWorkOrders(workOrders, sortField, isAscendingSort);
            return workOrders;
        }

        public static List<WorkOrder> SortWorkOrders(List<WorkOrder> workOrders, string sortField, bool isAscendingSort)
        {
            if (isAscendingSort)
            {
                if (sortField == "Name")
                {
                    workOrders = workOrders.OrderBy(x => x.Name).ToList();
                }
                else if (sortField == "DateStart")
                {
                    workOrders = workOrders.OrderBy(x => x.StartDate).ToList();
                }
                else if (sortField == "DateEnd")
                {
                    workOrders = workOrders.OrderBy(x => x.EndDate).ToList();
                }
                else if (sortField == "EstimateDateEnd")
                {
                    workOrders = workOrders.OrderBy(x => x.EstimatedEndDate).ToList();
                }
                else if (sortField == "Responsible")
                {
                    workOrders = workOrders.OrderBy(x => x.ResponsibleUser == null ? "" : x.ResponsibleUser.Fio).ToList();
                }
            }
            else
            {
                if (sortField == "Name")
                {
                    workOrders = workOrders.OrderByDescending(x => x.Name).ToList();
                }
                else if (sortField == "DateStart")
                {
                    workOrders = workOrders.OrderByDescending(x => x.StartDate).ToList();
                }
                else if (sortField == "DateEnd")
                {
                    workOrders = workOrders.OrderByDescending(x => x.EndDate).ToList();
                }
                else if (sortField == "EstimateDateEnd")
                {
                    workOrders = workOrders.OrderByDescending(x => x.EstimatedEndDate).ToList();
                }
                else if (sortField == "Counterparty")
                {
                    workOrders = workOrders.OrderByDescending(x => x.ResponsibleUser == null ? "" : x.ResponsibleUser.Fio).ToList();
                }
            }
            return workOrders;
        }

    }
}
