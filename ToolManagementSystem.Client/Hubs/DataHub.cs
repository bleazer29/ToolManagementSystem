using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolManagementSystem.Client.Hubs
{
    public class DataHub : Hub
    {
        public async Task SignalTest()
        {
            await this.Clients.All.SendAsync("recieve", "SignalR is working");
        }

    }
}
