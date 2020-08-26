using Microsoft.EntityFrameworkCore;
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

        public async Task<string> Create(Employees employees)
        {
            var singleEmployee = await db.Employee.SingleOrDefaultAsync(e=>e.FirstName == employees.FirstName && e.LastName == employees.LastName);
            if(singleEmployee != null)
            {
                return "Failed!";
            }
            await db.Employee.AddAsync(employees);
            await db.SaveChangesAsync();
            return "Success!";
        }

        public async Task<Employees> GetEmployeeById(int id)
        {
            return await db.Employee.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<string> EditEmployee(Employees employees)
        {
            var employee = await db.Employee.SingleOrDefaultAsync(e => e.FirstName == employees.FirstName && e.Patronymic == employees.Patronymic && e.LastName == employees.LastName);
            if (employee != null)
            {
                return "Not edited!";
            }
            db.Employee.Update(employees);
            await db.SaveChangesAsync();
            return "Edited!";
        }

        public async Task DeleteEmployee(Employees employees)
        {
            db.Employee.Remove(employees);
            await db.SaveChangesAsync();
        }


        


    }
}
