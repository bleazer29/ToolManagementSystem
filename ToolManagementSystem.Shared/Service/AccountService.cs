using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToolManagementSystem.Shared.Data;
using ToolManagementSystem.Shared.Help;

namespace ToolManagementSystem.Shared.Service
{
    public class AccountService
    {

        private readonly ApplicationDbContext db;
        public AccountService(ApplicationDbContext db)
        {
            this.db = db;
        }


        public async Task<bool> SignIn(string userName, string password)
        {
            var list = await db.Employee.ToListAsync();
            for(int i = 0; i < list.Count; i++)
            {
                if (list[i].UserName == userName && list[i].Password == password)
                {
                    IsSignInOut.isSign = true;
                    IsSignInOut.userName = list[i].UserName;
                    break;
                }
                else
                {
                    IsSignInOut.isSign = false;
                    IsSignInOut.userName = "";
                }
            }
            return IsSignInOut.isSign;
        }



    }
}
