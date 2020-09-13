using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ToolManagementSystem.Shared.Models;

namespace ToolManagementSystem.Client.Managers
{
    public class OrdersManager
    {
        static string apiControllerName { get; set; } = "Orders";

        public async static Task<List<Order>> GetOrdersAsync(string filterByName, string filterByState, DateTime filterByDateFrom, DateTime filterByDateTo, string filterByWell, string filterByContract, string filterByCounterparty, string filterByResponsible, string sortField, bool isAscendingSort)
        {
            List<Order> orders = null;
            try
            {
            
                HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName + "?name=" + filterByName +"&status=" + filterByState + "&startDate=" + filterByDateFrom.ToString("yyyy-MM-dd") + "&endDate=" + filterByDateTo.ToString("yyyy-MM-dd") + "&well=" + filterByWell + "&counterparty=" + filterByCounterparty + "&responsible=" + filterByResponsible + "&contract=" + filterByContract);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    orders = JsonConvert.DeserializeObject<List<Order>>(apiResponse);
                    if (isAscendingSort)
                    {
                        if (sortField == "Name")
                        {
                            orders = orders.OrderBy(x => x.Name).ToList();
                        }
                        else if (sortField == "State")
                        {
                            orders = orders.OrderBy(x => x.OrderStatus).ToList();
                        }
                        else if (sortField == "FromDate")
                        {
                            orders = orders.OrderBy(x => x.StartDate).ToList();
                        }
                        else if (sortField == "ToDateEstimated")
                        {
                            orders = orders.OrderBy(x => x.EstimatedEndDate).ToList();
                        }
                        else if (sortField == "ToDate")
                        {
                            orders = orders.OrderBy(x => x.EndDate).ToList();
                        }
                        else if (sortField == "Responsible")
                        {
                            orders = orders.OrderBy(x => x.ResponsibleUser.Fio).ToList();
                        }
                        else if (sortField == "Counterparty")
                        {
                            orders = orders.OrderBy(x => x.Counterparty.Name).ToList();
                        }
                        else if (sortField == "Contract")
                        {
                            orders = orders.OrderBy(x => x.Contract.Name).ToList();
                        }
                        else if (sortField == "Well")
                        {
                            orders = orders.OrderBy(x => x.Well.Name).ToList();
                        }
                    }
                    else
                    {
                        if (sortField == "Name")
                        {
                            orders = orders.OrderByDescending(x => x.Name).ToList();
                        }
                        else if (sortField == "State")
                        {
                            orders = orders.OrderByDescending(x => x.OrderStatus).ToList();
                        }
                        else if (sortField == "FromDate")
                        {
                            orders = orders.OrderByDescending(x => x.StartDate).ToList();
                        }
                        else if (sortField == "ToDateEstimated")
                        {
                            orders = orders.OrderByDescending(x => x.EstimatedEndDate).ToList();
                        }
                        else if (sortField == "ToDate")
                        {
                            orders = orders.OrderByDescending(x => x.EndDate).ToList();
                        }
                        else if (sortField == "Responsible")
                        {
                            orders = orders.OrderByDescending(x => x.ResponsibleUser.Fio).ToList();
                        }
                        else if (sortField == "Counterparty")
                        {
                            orders = orders.OrderByDescending(x => x.Counterparty.Name).ToList();
                        }
                        else if (sortField == "Contract")
                        {
                            orders = orders.OrderByDescending(x => x.Contract.Name).ToList();
                        }
                        else if (sortField == "Well")
                        {
                            orders = orders.OrderBy(x => x.Well.Name).ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return orders;
        }

        public async static Task<Order> GetOrderAsync(int id)
        {
            Order order = null;
            try
            {
                HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName + "/" + id);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    order = JsonConvert.DeserializeObject<Order>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return order;
        }

        public async static Task<System.Net.HttpStatusCode> CreateOrderAsync(Order newOrder)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(newOrder), Encoding.UTF8, "application/json");
                var response = await CustomHttpClient.GetClientInstance().PostAsync(apiControllerName, content);
                return response.StatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return System.Net.HttpStatusCode.BadRequest;
        }

        public async static Task<System.Net.HttpStatusCode> DeleteOrderAsync(int id)
        {
            try
            {
                var response = await CustomHttpClient.GetClientInstance().DeleteAsync(apiControllerName + "/" + id);
                return response.StatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return System.Net.HttpStatusCode.BadRequest;
        }

        public async static Task<System.Net.HttpStatusCode> UpdateOrderAsync(Order newOrder)
        {

            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(newOrder), Encoding.UTF8, "application/json");
                var response = await CustomHttpClient.GetClientInstance().PutAsync(apiControllerName + "/" + newOrder.OrderId, content);
                return response.StatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return System.Net.HttpStatusCode.BadRequest;
        }
    }
}
