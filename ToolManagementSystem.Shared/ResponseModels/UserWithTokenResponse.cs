using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ToolManagementSystem.Shared.Models;

namespace ToolManagementSystem.Shared.ResponseModels
{
    public class UserWithTokenResponse
    {
        public User User { get; set; }
        public string token { get; set; }
    }
}
