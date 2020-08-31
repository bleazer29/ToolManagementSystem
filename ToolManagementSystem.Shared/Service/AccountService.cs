using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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


        public async Task<bool> ResetPassword(string userName, string answer,string password)
        {
            var employee = await db.Employee.FirstOrDefaultAsync(x=>x.UserName.Equals(userName));
            if (employee != null)
            {
                if (employee.Answer.Equals(answer))
                {
                    if (employee.Password != password)
                    {
                        employee.Password = password;
                        db.Employee.Update(employee);
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }



    }
}
