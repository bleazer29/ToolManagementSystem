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
            List<Department> departments = await DepartmentsManager.GetDepartmentsAsync(filterByName, sortField, isAscendingSort);          
            string json = JsonConvert.SerializeObject(departments);
            await Clients.Caller.SendAsync("recieveDepartments", json);
        }

        public async Task GetCounterparties(string filterByName, string filterByEDRPOU, string filterByAddress, string sortField, bool isAscendingSort)
        {
            List<Counterparty> counterparties = await CounterpartiesManager.GetCounterpartiesAsync(filterByName, filterByEDRPOU, filterByAddress, sortField, isAscendingSort);
            string json = JsonConvert.SerializeObject(counterparties);
            await Clients.Caller.SendAsync("recieveCounterparties", json);
        }

        public async Task GetEditedCounterparty(int id)
        {
            Counterparty counterparty = await CounterpartiesManager.GetCounterpartyAsync(id);
            string json = JsonConvert.SerializeObject(counterparty);
            await Clients.Caller.SendAsync("recieveEditedCounterparty", json);
        }

        public async Task GetEditedStatus(int id)
        {
            ToolStatus toolStatus = await ToolStatusesManager.GetToolStatusAsync(id);
            string json = JsonConvert.SerializeObject(toolStatus);
            await Clients.Caller.SendAsync("recieveEditedStatus", json);
        }

        public async Task GetStatuses(string filterByName, string sortField, bool isAscendingSort)
        {
            List<ToolStatus> toolStatuses = await ToolStatusesManager.GetToolStatusesAsync(filterByName, sortField, isAscendingSort);
            string json = JsonConvert.SerializeObject(toolStatuses);
            await Clients.Caller.SendAsync("recieveStatuses", json);
        }

        public async Task GetEditedUnit(int id)
        {
            Unit unit = await UnitsManager.GetUnitAsync(id);
            string json = JsonConvert.SerializeObject(unit);
            await Clients.Caller.SendAsync("recieveEditedUnit", json);
        }

        public async Task GetUnits(string filterByName, string sortField, bool isAscendingSort)
        {
            List<Unit> units = await UnitsManager.GetUnitsAsync(filterByName, sortField, isAscendingSort);
            string json = JsonConvert.SerializeObject(units);
            await Clients.Caller.SendAsync("recieveUnits", json);
        }

        public async Task GetEditedSpecification(int id)
        {
            Specification specification = await SpecificationsManager.GetSpecificationAsync(id);
            string json = JsonConvert.SerializeObject(specification);
            await Clients.Caller.SendAsync("recieveEditedSpecification", json);
        }

        public async Task GetSpecifications(string filterByName, string sortField, bool isAscendingSort)
        {
            List<Specification> specifications = await SpecificationsManager.GetSpecificationsAsync(filterByName, sortField, isAscendingSort);
            string json = JsonConvert.SerializeObject(specifications);
            await Clients.Caller.SendAsync("recieveSpecifications", json);
        }

        public async Task GetEditedWell(int id)
        {
            Well well = await WellsManager.GetWellAsync(id);
            string json = JsonConvert.SerializeObject(well);
            await Clients.Caller.SendAsync("recieveEditedWell", json);
        }

        public async Task GetWells(string filterByName, string filterByAddress, string filterByWellNumber, string sortField, bool isAscendingSort)
        {
            List<Well> wells = await WellsManager.GetWellsAsync(filterByName, filterByAddress, filterByWellNumber, sortField, isAscendingSort);
            string json = JsonConvert.SerializeObject(wells);
            await Clients.Caller.SendAsync("recieveWells", json);
        }

        public async Task GetEditedClassification(int id)
        {
            ToolClassification classification = await ClassificationManager.GetClassificationAsync(id);
            string json = JsonConvert.SerializeObject(classification);
            await Clients.Caller.SendAsync("recieveEditedClassification", json);
        }

        public async Task GetClassifications(string filterByName, string sortField, bool isAscendingSort)
        {
            List<ToolClassification> classification = await ClassificationManager.GetClassificationsAsync(filterByName, sortField, isAscendingSort);
            string json = JsonConvert.SerializeObject(classification);
            await Clients.Caller.SendAsync("recieveClassifications", json);
        }


    }
}
