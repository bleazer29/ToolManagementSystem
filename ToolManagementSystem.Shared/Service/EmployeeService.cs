﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolManagementSystem.Shared.Data;
using ToolManagementSystem.Shared.Models;

namespace ToolManagementSystem.Shared.Service
{
    public class EmployeeService
    {
        private readonly ApplicationDbContext db;

        public EmployeeService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<Employees> GetEmployee()
        {
            return db.Employee.ToList();
        }

        public async Task Create(Employees employees)
        {
            var singleEmployee = await db.Employee.SingleOrDefaultAsync(e=>e.FirstName == employees.FirstName && e.LastName == employees.LastName);
            if(singleEmployee != null) return;

            if (db.Employee.Any(x=>x.UserName == employees.UserName)) return;

            await db.Employee.AddAsync(employees);
            await db.SaveChangesAsync();
        }

        public async Task<Employees> GetEmployeeById(int id)
        {
            return await db.Employee.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task EditEmployee(Employees employees)
        {
            var employee = await db.Employee.SingleOrDefaultAsync(e => e.FirstName == employees.FirstName && e.Patronymic == employees.Patronymic && e.LastName == employees.LastName);
            if (employee != null) return;
            if (db.Employee.Any(x => x.UserName == employees.UserName)) return;
            db.Employee.Update(employees);
            await db.SaveChangesAsync();
        }

        public async Task DeleteEmployee(Employees employees)
        {
            db.Employee.Remove(employees);
            await db.SaveChangesAsync();
        }


        


    }
}
