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

        public async Task GetDepartments(string filterByName, string sortField, bool isAscendingSort)
        {
            List<Department> departments = await DepartmentsManager.GetDepartmentsAsync(filterByName);
            if (isAscendingSort)
            {
                if (sortField == "Name")
                {
                    departments = departments.OrderBy(x => x.Name).ToList();                          
                }
            }
            else
            {
                if (sortField == "Name")
                {
                    departments = departments.OrderByDescending(x => x.Name).ToList();
                }
            } 
            string json = JsonConvert.SerializeObject(departments);
            await Clients.Caller.SendAsync("recieveDepartments", json);
        }

        public async Task GetCounterparties(string filterByName, string filterByEDRPOU, string filterByAddress, string sortField, bool isAscendingSort)
        {
            List<Counterparty> counterparties = await CounterpartiesManager.GetCounterpartiesAsync(filterByName, filterByEDRPOU, filterByAddress);
            if (isAscendingSort)
            {
                if (sortField == "Name")
                {
                    counterparties = counterparties.OrderBy(x => x.Name).ToList();
                }
                else if (sortField == "Edrpou")
                {
                    counterparties = counterparties.OrderBy(x => x.Edrpou).ToList();
                }
                else if (sortField == "Address")
                {
                    counterparties = counterparties.OrderBy(x => x.Address).ToList();
                }
            }
            else
            {
                if (sortField == "Name")
                {
                    counterparties = counterparties.OrderByDescending(x => x.Name).ToList();
                }
                else if (sortField == "Edrpou")
                {
                    counterparties = counterparties.OrderByDescending(x => x.Edrpou).ToList();
                }
                else if (sortField == "Address")
                {
                    counterparties = counterparties.OrderByDescending(x => x.Address).ToList();
                }
            }
            string json = JsonConvert.SerializeObject(counterparties);
            await Clients.Caller.SendAsync("recieveCounterparties", json);
        }

        public async Task GetEditedCounterparty(int id)
        {
            Counterparty counterparty = await CounterpartiesManager.GetCounterpartyAsync(id);
            string json = JsonConvert.SerializeObject(counterparty);
            await Clients.Caller.SendAsync("recieveEditedCounterparty", json);
        }

    }
}
