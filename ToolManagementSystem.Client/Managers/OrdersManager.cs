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
        static string apiControllerName { get; set; } = "NRI/Orders";

        public async static Task<List<Order>> GetOrdersAsync(string filterByName, string filterByState, string filterByDateFrom, string filterByDateTo, string filterByWell, string filterByContract, string filterByCounterparty, string filterByResponsible)
        {
            List<Order> orders = null;
            try
            {
                HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName + "?name=" + filterByName);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    orders = JsonConvert.DeserializeObject<List<Order>>(apiResponse);
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
