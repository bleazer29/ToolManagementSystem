using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolManagementSystem.Shared.Models;

namespace ToolManagementSystem.API.Controllers.AdminControllers
{
    [Route("api/Admin/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly TMSdbContext db;

        public UsersController(TMSdbContext context)
        {
            db = context;
        }

        // GET: api/Admin/Users
        [HttpGet]
        public async Task<IActionResult> GetUsers(string login)
        {
            try
            {
                List<User> users = await db.User
                    .Include(x => x.Department)
                    .ToListAsync();
                if (string.IsNullOrEmpty(login) == false)
                {
                    users = users.Where(x => x.Login.ToLower().Contains(login.ToLower())).ToList();
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // GET api/Admin/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                User user = await db.User.SingleAsync(x => x.UserId == id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // POST api/Admin/Users
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User value)
        {
            try
            {
                await db.User.AddAsync(value);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // PUT api/Admin/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditUser(int id, [FromBody] User value)
        {
            try
            {
                User user = await db.User.SingleAsync(x => x.UserId == id);
                if (user != null)
                {
                    user.Fio = value.Fio;
                    user.Login = value.Login;
                    user.Password = value.Password;
                    user.DepartmentId = value.DepartmentId;
                }
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // DELETE api/Admin/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                User user = await db.User.SingleAsync(x => x.UserId == id);
                db.User.Remove(user);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
    }
}
