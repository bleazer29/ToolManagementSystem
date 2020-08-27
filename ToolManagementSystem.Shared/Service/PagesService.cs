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

        public async Task<List<Pages>> GetAssignmentPages(int roleId)
        {
            var pagesRole = await db.RolesPage.AsNoTracking().Where(x => x.RoleId == roleId).ToListAsync();
            var listPages = await db.Page.AsNoTracking().ToListAsync();
            for (int i=0;i< listPages.Count;i++)
            {
                for (int j=0;j< pagesRole.Count;j++)
                {
                    if (pagesRole[j].PagesId == listPages[i].Id)
                    {
                        listPages[i].IsSelected = true;
                    }
                }
            }
            return listPages;
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
                    };

                    var singleEmployeeRole = db.RolesPage.AsNoTracking().Any(x => x.PagesId == page[i].Id && x.RoleId == roleId);

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
