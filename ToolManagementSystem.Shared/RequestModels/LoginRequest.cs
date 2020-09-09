using System;
using System.Collections.Generic;
using System.Text;

namespace ToolManagementSystem.Shared.RequestModels
{
    public class LoginRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
