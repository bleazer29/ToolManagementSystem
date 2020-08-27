using System;
using System.Collections.Generic;
using System.Text;
using ToolManagementSystem.Shared.Data;

namespace ToolManagementSystem.Shared.Service
{
    public class PagesService
    {
        private readonly ApplicationDbContext db;
        public PagesService(ApplicationDbContext db)
        {
            this.db = db;
        }



    }
}
