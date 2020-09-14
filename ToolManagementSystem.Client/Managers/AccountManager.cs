using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ToolManagementSystem.Shared.Models;
using ToolManagementSystem.Shared.RequestModels;

namespace ToolManagementSystem.Client.Managers
{
    public class AccountManager
    {
        private static string apiControllerName { get; } = "Accounts";
        public static User CurrentUser { get; set; }
        public async static Task<User> LoginAsync(string login, string pass)
        {
            User user = new User();
            HttpResponseMessage response = await CustomHttpClient.GetClientInstance().GetAsync(apiControllerName + "/Login" + "?Login=" + login + "&Password=" + pass);
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<User>(apiResponse);
                CurrentUser = user;
            }
            return user;
        }
    }
}
