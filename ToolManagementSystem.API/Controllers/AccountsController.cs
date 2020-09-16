using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ToolManagementSystem.Shared.Models;
using ToolManagementSystem.Shared.RequestModels;
using ToolManagementSystem.Shared.ResponseModels;

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
        [AllowAnonymous]
        [HttpGet("Login")]
        public async Task<IActionResult> Login(string Login, string Password)
        {
            try
            {
                User user = await db.User
                    .Include(x => x.UserRoleUser)
                        .ThenInclude(x => x.Role)
                            .ThenInclude(x => x.RolePermission)
                    .SingleAsync(x => x.Login == Login && x.Password == Password);
                if(user != null)
                {
                    var now = DateTime.UtcNow;
                    List<UserRole> userRoles = new List<UserRole>(user.UserRoleUser);
                    List<Claim> userClaims = new List<Claim>();
                    foreach (UserRole role in userRoles)
                    {
                        List<RolePermissionRight> rights = db.RolePermissionRight
                            .Include(x => x.RolePermission)
                                .ThenInclude(x => x.Permission)
                            .Include(x => x.Right)
                            .Where(x => x.RolePermission.RoleId == role.RoleId)
                            .ToList();
                        foreach (RolePermissionRight right in rights)
                        {
                            userClaims.Add(new Claim("user-right", right.RolePermission.Permission.Name + "-" + right.Right.Name));
                        }
                    }
                    var jwt = new JwtSecurityToken(
                            issuer: AuthenticationOptions.ISSUER,
                            audience: AuthenticationOptions.AUDIENCE,
                            notBefore: now,
                            claims: userClaims,
                            expires: now.Add(TimeSpan.FromDays(AuthenticationOptions.LIFETIME)),
                            signingCredentials: new SigningCredentials(AuthenticationOptions.GetSymmetricSecurityKey(),
                            SecurityAlgorithms.HmacSha256));
                    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
                    UserWithTokenResponse userWithToken = new UserWithTokenResponse()
                    {
                        User = user,
                        token = encodedJwt
                    };
                    return Ok(userWithToken);
                }
                return Problem(statusCode: 412, detail: "Пользователь не найден в базе данных");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Login failed User`s login is: {0}, pass: {1} \n" 
                    + ex.Message, Login, Password);
                return BadRequest();
            }
        }
    }
}
