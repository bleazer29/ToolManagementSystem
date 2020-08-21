using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            return await db.Role.ToListAsync();
        }

        public async Task CreateRole(Roles role)
        {
            var singleRole = await db.Role.SingleOrDefaultAsync(e => e.RoleName == role.RoleName);
            if (singleRole != null)
            {
                return;
            }
            await db.Role.AddAsync(role);
            await db.SaveChangesAsync();
        }


    }
}
