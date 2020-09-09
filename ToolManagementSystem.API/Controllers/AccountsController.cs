using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolManagementSystem.Shared.Models;

namespace ToolManagementSystem.API.Controllers
{
    [Route("api/Accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly TMSdbContext db;

        public AccountsController(TMSdbContext context)
        {
            db = context;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<User> Login([FromBody] string login, [FromBody] string pass)
        {
            try
            {
                User user = await db.User
                    .Include(x => x.UserRoleUser)
                        .ThenInclude(x => x.Role)
                    .SingleAsync(x => x.Login == login && x.Password == pass);
                if(user != null)
                {
                    return user;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Login failed \n" + ex.Message);
            }
            return new User() { UserId = -1 };
        }
    }
}
