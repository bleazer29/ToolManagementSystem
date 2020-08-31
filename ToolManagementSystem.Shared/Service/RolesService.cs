using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<List<Roles>> GetRoles()
        {
            return await db.Role.AsNoTracking().ToListAsync();
        }
        public Roles GetRoleById(int id)
        {
            return  db.Role.FirstOrDefault(r => r.Id == id);
        }


        public async Task<List<Roles>> GetAssignmentRole(int employeeId)
        {
            var employeeRoles = await db.EmployeeRole.AsNoTracking().Where(x => x.EmployeeId == employeeId).ToListAsync();
            var listRoles = await db.Role.AsNoTracking().ToListAsync();
            for (int i=0;i< listRoles.Count;i++)
            {
                for (int j = 0; j < employeeRoles.Count; j++)
                {
                    if (employeeRoles[j].RoleId == listRoles[i].Id)
                    {
                        listRoles[i].IsSelected = true;
                    }
                }
            }
            return listRoles;
        }

        public async Task<List<EmployeeRoles>> GetEmployeeRolesById(int employeeId)
        {
            return await db.EmployeeRole.AsNoTracking().Where(x => x.EmployeeId == employeeId).ToListAsync();
        }

        public async Task CreateRole(Roles role)
        {
            var singleRole = await db.Role.AsNoTracking().SingleOrDefaultAsync(r => r.RoleName == role.RoleName);
            if (singleRole != null || role.RoleName==null) return;
            await db.Role.AddAsync(role);
            await db.SaveChangesAsync();
        }

        
        public async Task EditRole(Roles role)
        {
            var singleRoles = await db.Role.AsNoTracking().SingleOrDefaultAsync(r => r.RoleName == role.RoleName);
            if (singleRoles != null || role.RoleName == null) return;
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
                    };

                    var singleEmployeeRole = db.EmployeeRole.AsNoTracking().Any(x => x.EmployeeId == userId && x.RoleId == role[i].Id);
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
                    
                }
            }
            catch { return; }
        }

        public async Task DeleteRole(Roles roles)
        {
            try
            {
                var listRolesPages = db.RolesPage.AsNoTracking().Where(x => x.RoleId == roles.Id).ToList();
                if (listRolesPages.Count != 0)
                {
                    foreach (var item in listRolesPages)
                    {
                        db.RolesPage.Remove(item);
                    }
                    await db.SaveChangesAsync();
                }
                db.Role.Remove(roles);
                await db.SaveChangesAsync();
                /////
            }
            catch { return; }
        }



    }
}
