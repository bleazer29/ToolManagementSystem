using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolManagementSystem.Shared.Models;
using ToolManagementSystem.Shared.RequestModels;

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

        // GET: api/Accounts/Login
        [HttpGet("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                User user = await db.User
                    .Include(x => x.UserRoleUser)
                        .ThenInclude(x => x.Role)
                    .SingleAsync(x => x.Login == request.Login && x.Password == request.Password);
                if(user != null)
                {
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Login failed User`s login is: {0}, pass: {1} \n" + ex.Message, request.Login, request.Password);
            }
            return BadRequest();
        }
    }
}
