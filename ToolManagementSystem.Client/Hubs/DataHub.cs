using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolManagementSystem.Client.Managers.NRI;
using ToolManagementSystem.Shared.Models;

namespace ToolManagementSystem.Client.Hubs
{
    public class DataHub : Hub
    {
        public async Task SignalTest()
        {
            await this.Clients.All.SendAsync("recieve", "SignalR is working");
        }

        public async Task GetEditedDepartment(int id)
        {
            Department department = await DepartmentsManager.GetDepartmentAsync(id);
            string json = JsonConvert.SerializeObject(department);
            await Clients.Caller.SendAsync("recieveEditedDepartment", json);
        }

    }
}
