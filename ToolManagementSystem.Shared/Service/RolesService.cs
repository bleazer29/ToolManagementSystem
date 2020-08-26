using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolManagementSystem.Shared.Data;
using ToolManagementSystem.Shared.Models;

namespace ToolManagementSystem.Shared.Service
{
    public class RolesService
    {
        private readonly ApplicationDbContext db;

        public RolesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<Roles> GetRoles()
        {
            return db.Role.AsNoTracking().ToList();
        }
        public Roles GetRoleById(int id)
        {
            return db.Role.FirstOrDefault(r => r.Id == id);
        }

        public async Task<List<EmployeeRoles>> GetEmployeeRolesById(int userId)
        {
            return await db.EmployeeRole.AsNoTracking().Where(x => x.EmployeeId == userId).ToListAsync();
        }

        //public Employees GetEmployee(string userId)
        //{
        //    return db.Employee.FirstOrDefault(e=>e.Id == Convert.ToInt32(userId));
        //}


        public async Task CreateRole(Roles role)
        {
            var singleRole = await db.Role.SingleOrDefaultAsync(r => r.RoleName == role.RoleName);
            if (singleRole != null)  return;
            await db.Role.AddAsync(role);
            await db.SaveChangesAsync();
        }

        
        public async Task EditRole(Roles role)
        {
            var singleRoles = await db.Role.SingleOrDefaultAsync(r => r.RoleName == role.RoleName);
            if (singleRoles != null) return;
            db.Role.Update(role);
            await db.SaveChangesAsync();
        }

        public async Task EditUsersInRole(List<Roles> role, int userId)
        {
            try
            {
                for (int i = 0; i < role.Count; i++)
                {
                    EmployeeRoles result = new EmployeeRoles {
                       EmployeeId = userId,
                       RoleId = role[i].Id
                       //IsSelected = role[i].IsSelected
                    };

                    var singleEmployeeRole = db.EmployeeRole.AsNoTracking().Any(x => x.EmployeeId == userId && x.RoleId == role[i].Id);

                    //if (role[i].IsSelected && !db.EmployeeRole.AsNoTracking().Where(x => x.EmployeeId == userId && x.RoleId == role[i].Id).Any())
                    if (role[i].IsSelected && !singleEmployeeRole)
                    {
                        db.EmployeeRole.Add(result);
                    }
                    else if (!role[i].IsSelected && singleEmployeeRole)
                    {
                        db.EmployeeRole.Remove(db.EmployeeRole.FirstOrDefault(x => x.EmployeeId == userId && x.RoleId == role[i].Id));
                    }
                    else continue;
                    await db.SaveChangesAsync();

                    //if (i < (role.Count - 1)) continue;
                    
                }
            }
            catch { return; }
        }

        public async Task DeleteRole(Roles roles)
        {
            db.Role.Remove(roles);
            await db.SaveChangesAsync();
        }

    }
}
