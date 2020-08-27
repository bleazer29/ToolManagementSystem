using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolManagementSystem.Shared.Data;
using ToolManagementSystem.Shared.Models;

namespace ToolManagementSystem.Shared.Service
{
    public class PagesService
    {
        private readonly ApplicationDbContext db;
        public PagesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<Pages> GetPages()
        {
            return db.Page.AsNoTracking().ToList();
        }

        public async Task<List<RolesPages>> GetPagesRolesById(int roleId)
        {
            return await db.RolesPage.AsNoTracking().Where(x => x.RoleId == roleId).ToListAsync();
        }

        public async Task EditPagesInRole(List<Pages> page, int roleId)
        {
            try
            {
                for (int i = 0; i < page.Count; i++)
                {
                    RolesPages result = new RolesPages
                    {
                        RoleId = roleId,
                        PagesId = page[i].Id
                        //IsSelected = role[i].IsSelected
                    };

                    var singleEmployeeRole = db.RolesPage.AsNoTracking().Any(x => x.PagesId == page[i].Id && x.RoleId == roleId);

                    //if (role[i].IsSelected && !db.EmployeeRole.AsNoTracking().Where(x => x.EmployeeId == userId && x.RoleId == role[i].Id).Any())
                    if (page[i].IsSelected && !singleEmployeeRole)
                    {
                        db.RolesPage.Add(result);
                    }
                    else if (!page[i].IsSelected && singleEmployeeRole)
                    {
                        db.RolesPage.Remove(db.RolesPage.FirstOrDefault(x => x.PagesId == page[i].Id && x.RoleId == roleId));
                    }
                    else continue;
                    await db.SaveChangesAsync();

                }
            }
            catch { return; }
        }




    }
}
